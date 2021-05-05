using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Collections;

namespace ExcelToAzure
{

    public static class SQL
    {
        static string ServerName = "euteg8yt58.database.windows.net";
        static string Database = "LAPRECON", username = "AAAzureAdminLAPRECON", password = "wer.asc%)$#B4weAbsd234:)";
        static string ConnectionString = "";


        private static SqlConnection Connection() => new SqlConnection(ConnectionString);
        public static bool Connect(string user, string pass)
        {
            user = user.ToLower();
            try
            {
                var result = false;
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = ServerName;
                builder.UserID = username;
                builder.Password = password;
                builder.InitialCatalog = Database;
                ConnectionString = builder.ConnectionString;

                using (var connection = Connection())
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT * from [user] where LOWER(name) like @user and password like @pass and active = 1 for JSON PATH;");
                    String sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("user", user);
                        command.Parameters.AddWithValue("pass", pass);
                        var reader = (string)command.ExecuteScalar();

                        var returnuser = JsonConvert.DeserializeObject<List<User>>(reader).First();
                        if (returnuser.id != -1)
                        {
                            User.LoggedIn = returnuser.New();
                            result = true;
                        }
                    }
                }
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        internal static int InsertPhase(Phase phase)
        {
            string cmdtext = "BEGIN "+
                        "IF NOT EXISTS (SELECT phase FROM project_phase WHERE phase = @phase and project_id = @project_id) " +
                            "BEGIN "+
                                "INSERT INTO project_phase (phase, project_id) " + 
                                "output inserted.id values (@phase, @project_id) " +
                            "END " +
                        "ELSE "+
                            "SELECT id FROM project_phase WHERE phase = @phase and project_id = @project_id " +
                        "END";

            try
            {
                using (var connection = Connection())
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    using (var command = new SqlCommand(cmdtext, connection, transaction))
                    {
                        try
                        {
                            command.Parameters.AddWithValue("phase", phase.phase);
                            command.Parameters.AddWithValue("project_id", phase.project.id);

                            phase.id = (int)command.ExecuteScalar();

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error executing {0}\nerror:{1}", cmdtext, ex.Message);
                            PrivateClasses.SafeInvoke(() => MessageBox.Show(ex.Message));
                            transaction.Rollback();
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error executing {0}\nerror:{1}", cmdtext, e.Message);
                PrivateClasses.SafeInvoke(() => MessageBox.Show(e.Message));
            }
            return phase.id;
        }

        internal static string QuerryGet(string commandtext)
        {
            string res = "[]";
            try
            {
                commandtext = commandtext.Trim(new char[] { ' ', ';' });
                commandtext += " FOR JSON PATH;";
                using (var connection = Connection())
                using (var command = new SqlCommand(commandtext, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        res = reader.GetString(0) ?? "[]";
                    }
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error executing {0}\nerror:{1}", commandtext, e.Message);
            }
            return res;
        }

        internal static bool QuerryUpdate(string commandtext)
        {
            try
            {
                commandtext = commandtext.Trim();
                using (var connection = Connection())
                using (var command = new SqlCommand(commandtext, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error executing {0}\nerror:{1}", commandtext, e.Message);
            }
            return false;
        }

        internal static bool UpdateProject(Project project)
        {
            bool success = false;
            string cmdtext = project.id == -1 ?
                "insert into project (name, description, owner, type, duration, gsf) output inserted.id values (@name, @description, @owner, @type, @duration, @gsf);"
                :
                "update project set name = @name, description = @description, owner = @owner, type = @type, duration = @duration, gsf = @gsf output inserted.id where id = @id;";

            try
            {
                using (var connection = Connection())
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    using (var command = new SqlCommand(cmdtext, connection, transaction))
                    {
                        try
                        {
                            command.Parameters.AddWithValue("id", project.id);
                            command.Parameters.AddWithValue("name", project.name);
                            command.Parameters.AddWithValue("description", project.description);
                            command.Parameters.AddWithValue("owner", project.owner);
                            command.Parameters.AddWithValue("type", project.type);
                            command.Parameters.AddWithValue("duration", project.duration);
                            command.Parameters.AddWithValue("gsf", project.gsf);

                            project.id = (int)command.ExecuteScalar();

                            transaction.Commit();
                            success = project.id != -1;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error executing {0}\nerror:{1}", cmdtext, ex.Message);
                            PrivateClasses.SafeInvoke(() => MessageBox.Show(ex.Message));
                            transaction.Rollback();
                            success = false;
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error executing {0}\nerror:{1}", cmdtext, e.Message);
                PrivateClasses.SafeInvoke(() => MessageBox.Show(e.Message));
                success = false;
            }
            return success;
        }

        internal static List<Record> GetAllRecords()
        {
            var all = new List<Record>();
            string cmdtxt = "select (select r.*, " +
                            "price.unit_price as price, " +
                            "(select * from project_phase where id = r.phase_id for json auto) as phase, " +
                            "(select l.*, project.* from location l left join project on l.project_id = project.id where l.id = r.location_id for json auto) as location, " +
                            "(select t.*, level.* from template t left join levels level on t.level_id = level.id where t.id = r.template_id for json auto) as template " +
                            "from record r left join product_price price on (r.project_id = price.project_id and r.template_id = price.template_id and(r.phase_id is null or r.phase_id = price.phase_id)) " +
                            "where r.id = x.id for json path) from record x";
            QuerryRecords(cmdtxt).ForEach(row =>
            {
                try
                {
                    var result = JsonConvert.DeserializeObject<Record>(row);
                    all.Add(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Failed to serialize record:\n{1}\ne:{0}", e.Message, row);
                }
            });
            return all;
        }

        private static List<string> QuerryRecords(string commandtext)
        {
            var count = QuerryGet("select count(id) as count from record ").ToInt();
            LoadingData.Instance.SafeInvoke(x =>
            {
                LoadingData.ProgressText = string.Format("Loading 0 out of {0} records...", count.ToString());
                LoadingData.Maximum = count;
                LoadingData.Value = 0;
            });
            var all = new List<string>();
            try
            {
                using (var connection = Connection())
                using (var command = new SqlCommand(commandtext, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            all.Add((reader.GetString(0) ?? "{}").Replace("[", "").Replace("]", ""));
                            Form1.Bar.SafeInvoke(x =>
                            {
                                LoadingData.Value++;
                                LoadingData.ProgressText = string.Format("Loading {0} out of {1} records...", LoadingData.Value.ToString(), count.ToString());
                            });
                        }
                    }
                    connection.Close();
                }
                LoadingData.Instance.SafeInvoke(x =>
                {
                    LoadingData.ProgressText = string.Format("Loaded {0} out of {1} records.", LoadingData.Value.ToString(), count.ToString());
                });
            }
            catch (Exception e)
            {
                Console.WriteLine("Error executing {0}\nerror:{1}", commandtext, e.Message);
            }
            return all;
        }

        public static bool ImportNewData(List<Record> records, List<Location> locations, List<Level1> level1s, List<Level2> level2s, List<Level3> level3s, List<Level4> level4s)
        {
            bool success_all = false;
            string computer_that_imported = System.Windows.Forms.SystemInformation.ComputerName;
            string level1txt = "BEGIN IF NOT EXISTS (select id from level_1 where UPPER(code) = UPPER(@code) and project_id = @project_id) " +
                               "BEGIN INSERT INTO level_1(code, project_id, description) output inserted.id values(@code, @project_id, @description) END " +
                               "ELSE SELECT id FROM level_1 WHERE UPPER(code) = UPPER(@code) and project_id = @project_id END; ";
            string level2txt = "BEGIN IF NOT EXISTS (select id from level_2 where UPPER(code) = UPPER(@code) and level1_id = @level1_id) " +
                               "BEGIN INSERT INTO level_2(code, level1_id, description) output inserted.id values(@code, @level1_id, @description) END " +
                               "ELSE SELECT id FROM level_2 WHERE UPPER(code) = UPPER(@code) and level1_id = @level1_id END; ";
            string level3txt = "BEGIN IF NOT EXISTS (select id from level_3 where UPPER(code) = UPPER(@code) and level2_id = @level2_id) " +
                               "BEGIN INSERT INTO level_3(code, level2_id, description) output inserted.id values(@code, @level2_id, @description) END " +
                               "ELSE SELECT id FROM level_3 WHERE UPPER(code) = UPPER(@code) and level2_id = @level2_id END; ";
            string level4txt = "BEGIN IF NOT EXISTS (select id from level_4 where UPPER(code) = UPPER(@code) and level3_id = @level3_id) " +
                               "BEGIN INSERT INTO level_4(code, level3_id, description) output inserted.id values(@code, @level3_id, @description) END " +
                               "ELSE SELECT id FROM level_4 WHERE UPPER(code) = UPPER(@code) and level3_id = @level3_id END; ";
            string level1qty = "WITH del AS (DELETE FROM level1_qty WHERE level1_id = @level1_id and phase_id = @phase_id) " +
                               "INSERT INTO level1_qty (level1_id, phase_id, qty, uom) VALUES (@level1_id, @phase_id, @qty, @uom) ; ";
            string level2qty = "WITH del AS (DELETE FROM level2_qty WHERE level2_id = @level2_id and phase_id = @phase_id) " +
                               "INSERT INTO level2_qty (level2_id, phase_id, qty, uom) VALUES (@level2_id, @phase_id, @qty, @uom) ; ";
            string level3qty = "WITH del AS (DELETE FROM level3_qty WHERE level3_id = @level3_id and phase_id = @phase_id) " +
                               "INSERT INTO level3_qty (level3_id, phase_id, qty, uom) VALUES (@level3_id, @phase_id, @qty, @uom) ; ";
            string level4qty = "WITH del AS (DELETE FROM level4_qty WHERE level4_id = @level4_id and phase_id = @phase_id) " +
                               "INSERT INTO level4_qty (level4_id, phase_id, qty, uom) VALUES (@level4_id, @phase_id, @qty, @uom) ; ";
            string templatetxt = "BEGIN IF NOT EXISTS (select id from template where UPPER(code) = UPPER(@code) and level4_id = @level4_id) " +
                                 "BEGIN INSERT INTO template(code, level4_id, description, ut) output inserted.id values(@code, @level4_id, @description, @ut) END " +
                                 "ELSE SELECT id FROM template WHERE UPPER(code) = UPPER(@code) and level4_id = @level4_id END; ";
            string locationtxt = "BEGIN IF NOT EXISTS (select id from location where project_id = project_id and UPPER(code) = UPPER(@code) and UPPER(name) = UPPER(@name)) " +
                                 "BEGIN INSERT INTO location(project_id, code, name, sf) output inserted.id values(@project_id, @code, @name, @sf) END " +
                                 "ELSE select id from location where project_id = project_id and UPPER(code) = UPPER(@code) and UPPER(name) = UPPER(@name) END ";
            string tradecodetxt = "BEGIN IF NOT EXISTS (select id from trade_code where UPPER(code) = UPPER(@code)) " +
                                  "BEGIN INSERT INTO trade_code (code) output inserted.id values(@code) END " +
                                  "ELSE SELECT id FROM trade_code WHERE UPPER(code) = UPPER(@code) END; ";
            string csicodetxt = "BEGIN IF NOT EXISTS (select id from csi_code where UPPER(code) = UPPER(@code) and trade_code_id = @trade_code_id) " +
                                  "BEGIN INSERT INTO csi_code (code, trade_code_id) output inserted.id values(@code, @trade_code_id) END " +
                                  "ELSE SELECT id FROM csi_code WHERE UPPER(code) = UPPER(@code) and trade_code_id = @trade_code_id END; ";
            string recordtxt = "INSERT INTO record (template_id, qty, extension, comments, csi_code_id, estimate_category, location_id, phase_id, batch_id, active) " +
                      "output inserted.id values (@template_id, @qty, @extension, @comments, @csi_code_id, @estimate_category, @location_id, @phase_id, @batch_id, 1); ";
            string updateactive = "UPDATE record SET active = 0 WHERE phase_id = @phase_id; ";
            string batchtxt = "insert into batch(user_id) output inserted.id values(@user_id); ";
                               

            Form1.Bar.SafeInvoke(x =>
            {
                x.Maximum = records.Count() + locations.Count() + level1s.Count() + +level2s.Count() + level3s.Count() + level4s.Count();
                x.Value = 0;
                x.Visible = true;
            });
            using (var connection = Connection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                using (var batchcmd = new SqlCommand(batchtxt, connection, transaction))
                using (var updateactivecmd = new SqlCommand(updateactive, connection, transaction))
                {
                    int project_id = records.First().phase.project.id;
                    int phase_id = records.First().phase.id;
                    try
                    {
                        records.ForEach(r =>
                        {
                            if (!level1s.Select(l => l.code).Contains(r.template.level4.level3.level2.level1.code))
                                level1s.Add(r.template.level4.level3.level2.level1);
                            if (!level2s.Select(l => l.code).Contains(r.template.level4.level3.level2.code))
                                level2s.Add(r.template.level4.level3.level2);
                            if (!level3s.Select(l => l.code).Contains(r.template.level4.level3.code))
                                level3s.Add(r.template.level4.level3);
                            if (!level4s.Select(l => l.code).Contains(r.template.level4.code))
                                level4s.Add(r.template.level4);
                        });
                        level1s.ForEach(level =>
                        {
                            using (var levelscmd = new SqlCommand(level1txt, connection, transaction))
                            using (var levelqtycmd = new SqlCommand(level1qty, connection, transaction))
                            {
                                levelscmd.Parameters.AddWithValue("code", level.code);
                                levelscmd.Parameters.AddWithValue("project_id", project_id);
                                levelscmd.Parameters.AddWithValue("description", level.description);

                                level.id = (int)levelscmd.ExecuteScalar();
                                records.ForEach(x =>
                                {
                                    if (x.template.level4.level3.level2.level1.code == level.code)
                                        x.template.level4.level3.level2.level1.id = level.id;
                                });

                                levelqtycmd.Parameters.AddWithValue("phase_id", phase_id);
                                levelqtycmd.Parameters.AddWithValue("level1_id", level.id);
                                levelqtycmd.Parameters.AddWithValue("qty", level.Phase_UOM_qty.Item3);
                                levelqtycmd.Parameters.AddWithValue("uom", level.Phase_UOM_qty.Item2);
                                Form1.Bar.SafeInvoke(x => x.Value++);
                            }
                        });
                        level2s.ForEach(level =>
                        {
                            using (var levelscmd = new SqlCommand(level2txt, connection, transaction))
                            using (var levelqtycmd = new SqlCommand(level2qty, connection, transaction))
                            {
                                levelscmd.Parameters.AddWithValue("code", level.code);
                                levelscmd.Parameters.AddWithValue("level1_id", level.level1.id);
                                levelscmd.Parameters.AddWithValue("description", level.description);

                                level.id = (int)levelscmd.ExecuteScalar();
                                records.ForEach(x =>
                                {
                                    if (x.template.level4.level3.level2.code == level.code && level.level1.id == x.template.level4.level3.level2.level1.id)
                                        x.template.level4.level3.level2.id = level.id;
                                });

                                levelqtycmd.Parameters.AddWithValue("phase_id", phase_id);
                                levelqtycmd.Parameters.AddWithValue("level2_id", level.id);
                                levelqtycmd.Parameters.AddWithValue("qty", level.Phase_UOM_qty.Item3);
                                levelqtycmd.Parameters.AddWithValue("uom", level.Phase_UOM_qty.Item2);
                                Form1.Bar.SafeInvoke(x => x.Value++);
                            }
                        });
                        level3s.ForEach(level =>
                        {
                            using (var levelscmd = new SqlCommand(level3txt, connection, transaction))
                            using (var levelqtycmd = new SqlCommand(level3qty, connection, transaction))
                            {
                                levelscmd.Parameters.AddWithValue("code", level.code);
                                levelscmd.Parameters.AddWithValue("level2_id", level.level2.id);
                                levelscmd.Parameters.AddWithValue("description", level.description);

                                level.id = (int)levelscmd.ExecuteScalar();
                                records.ForEach(x =>
                                {
                                    if (x.template.level4.level3.code == level.code && level.level2.id == x.template.level4.level3.level2.id)
                                        x.template.level4.level3.id = level.id;
                                });

                                levelqtycmd.Parameters.AddWithValue("phase_id", phase_id);
                                levelqtycmd.Parameters.AddWithValue("level3_id", level.id);
                                levelqtycmd.Parameters.AddWithValue("qty", level.Phase_UOM_qty.Item3);
                                levelqtycmd.Parameters.AddWithValue("uom", level.Phase_UOM_qty.Item2);
                                Form1.Bar.SafeInvoke(x => x.Value++);
                            }
                        });
                        level4s.ForEach(level =>
                        {
                            using (var levelscmd = new SqlCommand(level4txt, connection, transaction))
                            using (var levelqtycmd = new SqlCommand(level4qty, connection, transaction))
                            {
                                levelscmd.Parameters.AddWithValue("code", level.code);
                                levelscmd.Parameters.AddWithValue("level3_id", level.level3.id);
                                levelscmd.Parameters.AddWithValue("description", level.description);

                                level.id = (int)levelscmd.ExecuteScalar();
                                records.ForEach(x =>
                                {
                                    if (x.template.level4.code == level.code && level.level3.id == x.template.level4.level3.id)
                                        x.template.level4.id = level.id;
                                });

                                levelqtycmd.Parameters.AddWithValue("phase_id", phase_id);
                                levelqtycmd.Parameters.AddWithValue("level4_id", level.id);
                                levelqtycmd.Parameters.AddWithValue("qty", level.Phase_UOM_qty.Item3);
                                levelqtycmd.Parameters.AddWithValue("uom", level.Phase_UOM_qty.Item2);
                                Form1.Bar.SafeInvoke(x => x.Value++);
                            }
                        });
                        locations.ForEach(locs =>
                        {
                            using (var locationcmd = new SqlCommand(locationtxt, connection, transaction))
                            {
                                locationcmd.Parameters.AddWithValue("code", locs.code);
                                locationcmd.Parameters.AddWithValue("project_id", project_id);
                                locationcmd.Parameters.AddWithValue("name", locs.name);
                                locationcmd.Parameters.AddWithValue("sf", locs.sf);

                                locs.id = (int)locationcmd.ExecuteScalar();
                                records.ForEach(x =>
                                {
                                    if (x.location.code == locs.code)
                                        x.location.id = locs.id;
                                });
                                Form1.Bar.SafeInvoke(x => x.Value++);
                            }
                        });
                        var templates = records.Select(x => x.template).DistinctBy(x => x.code + "$$" + x.level4.id.ToString()).ToList();
                        templates.ForEach(templ =>
                        {
                            using (var templatescmd = new SqlCommand(templatetxt, connection, transaction))
                            {
                                templatescmd.Parameters.AddWithValue("code", templ.code);
                                templatescmd.Parameters.AddWithValue("level4_id", templ.level4.id);
                                templatescmd.Parameters.AddWithValue("description", templ.description);
                                templatescmd.Parameters.AddWithValue("ut", templ.ut);
                                templ.id = (int)templatescmd.ExecuteScalar();
                                records.ForEach(x =>
                                {
                                    if (x.template.code == templ.code && x.template.level4.id == templ.level4.id)
                                        x.template.id = templ.id;
                                });
                            }
                        });
                        var tradecodes = records.Select(x => x.csi_code.trade_code).DistinctBy(x => x.code).ToList();
                        tradecodes.ForEach(tcodes =>
                        {
                            using (var tradecmd = new SqlCommand(tradecodetxt, connection, transaction))
                            {
                                tradecmd.Parameters.AddWithValue("code", tcodes.code);

                                tcodes.id = (int)tradecmd.ExecuteScalar();
                                records.ForEach(x =>
                                {
                                    if (x.csi_code.trade_code.code == tcodes.code)
                                        x.csi_code.trade_code.id = tcodes.id;
                                });
                            }
                        }); 
                        var csicodes = records.Select(x => x.csi_code).DistinctBy(x => x.code + "$$" + x.trade_code.id.ToString()).ToList();
                        csicodes.ForEach(csicode =>
                        {
                            using (var csicmd = new SqlCommand(csicodetxt, connection, transaction))
                            {
                                csicmd.Parameters.AddWithValue("code", csicode.code);
                                csicmd.Parameters.AddWithValue("trade_code_id", csicode.trade_code.id);

                                csicode.id = (int)csicmd.ExecuteScalar();
                                records.ForEach(x =>
                                {
                                    if (x.csi_code.code == csicode.code && x.csi_code.trade_code.id == csicode.trade_code.id)
                                        x.csi_code.id = csicode.id;
                                });
                            }
                        });
                        batchcmd.Parameters.AddWithValue("user_id", User.LoggedIn.id);
                        updateactivecmd.Parameters.AddWithValue("phase_id", phase_id);
                        updateactivecmd.ExecuteScalar();
                        int batch_id = (int)batchcmd.ExecuteScalar();

                        records.ForEach(record =>
                        {
                            using (var recordcmd = new SqlCommand(recordtxt, connection, transaction))
                            {
                                recordcmd.Parameters.AddWithValue("batch_id", batch_id);
                                recordcmd.Parameters.AddWithValue("template_id", record.template.id);
                                recordcmd.Parameters.AddWithValue("phase_id", phase_id);
                                recordcmd.Parameters.AddWithValue("location_id", record.location.id);
                                recordcmd.Parameters.AddWithValue("qty", record.qty);
                                recordcmd.Parameters.AddWithValue("extension", record.total);
                                recordcmd.Parameters.AddWithValue("comments", record.comments);
                                recordcmd.Parameters.AddWithValue("csi_code_id", record.csi_code.id);
                                recordcmd.Parameters.AddWithValue("estimate_category", record.estimate_category);

                                record.id = (int)recordcmd.ExecuteScalar();
                                //Console.WriteLine(JsonConvert.SerializeObject(record));
                                recordcmd.Dispose();

                                success_all = record.id != -1;
                                Form1.Bar.SafeInvoke(x => x.Value = x.Value == x.Maximum ? x.Value : (x.Value + 1));
                            }
                        });
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error executing {0}\nerror:{1}", "ImportNewData", e.Message);
                        PrivateClasses.SafeInvoke(() => MessageBox.Show(Form1.Bar.Value.ToString() + " were successfully imported", "Some records were not imported"));
                        transaction.Rollback();
                        connection.Close();
                        Form1.Bar.SafeInvoke(x => x.Value = 0);
                        return false;
                    }
                }
                connection.Close();
            }
            Form1.Bar.SafeInvoke(x => x.Visible = false);
            return success_all;
        }
    }
}
