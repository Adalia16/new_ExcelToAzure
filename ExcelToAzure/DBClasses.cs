using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ExcelToAzure
{
    public interface DBInterface
    {
    }

    public class User : DBInterface
    {
        [JsonProperty("id")]
        public int id = -1;
        [JsonProperty("active")]
        public bool active = true;
        [JsonProperty("name")]
        public string name = "";
        [JsonProperty("password")]
        public string password = "";

        public static User LoggedIn = new User();
    }
    public class Project : DBInterface
    {
        [JsonProperty("id")]
        public int id = -1;
        [JsonProperty("name")]
        public string name = "";
        [JsonProperty("description")]
        public string description = "";
        [JsonProperty("owner")]
        public string owner = "";
        [JsonProperty("type")]
        public string type = "";
        [JsonProperty("duration")]
        public decimal duration = 0;
        [JsonProperty("gsf")]
        public decimal gsf = 0;
        [JsonProperty("properties")]
        public string properties = "";

        public Project()
        {
        }

        public async void Update(Action<bool> success)
        {
            bool ok = false;
            await Task.Run(() => ok = SQL.UpdateProject(this));
            success?.Invoke(ok);
        }

        public static async void GetAll(Action<List<Project>> result)
        {
            var command = "select * from project";
            var all = new List<Project>();
            await Task.Run(() => all = JsonConvert.DeserializeObject<List<Project>>(SQL.QuerryGet(command)));
            result?.Invoke(all);
        }

        public async void GetLocations(Action<List<Location>> result)
        {
            var command = "select * from location where project_id = " + id.ToString();
            var all = new List<Location>();
            await Task.Run(() => all = JsonConvert.DeserializeObject<List<Location>>(SQL.QuerryGet(command)));
            result?.Invoke(all);
        }
    }

    public class Phase : DBInterface
    {
        [JsonProperty("id")]
        public int id = -1;
        [JsonProperty("phase")]
        public string phase = "";
        [JsonProperty("project")]
        public Project project = new Project();

        public Phase()
        {
        }

        public async void Update(Action<Phase> success)
        {
            await Task.Run(() => id = SQL.InsertPhase(this));
            success?.Invoke(this);
        }

        public static async void GetAll(Action<List<Phase>> result)
        {
            var command = "select * from project_phase";
            var all = new List<Phase>();
            await Task.Run(() => all = JsonConvert.DeserializeObject<List<Phase>>(SQL.QuerryGet(command)));
            result?.Invoke(all);
        }
    }

    public class Level1 : DBInterface
    {
        [JsonProperty("id")]
        public int id = -1;
        [JsonProperty("description")]
        public string description = "";
        [JsonProperty("code")]
        public string code = "";
        [JsonProperty("project")]
        public Project project = new Project();
        [JsonIgnore]
        public (Phase, string, decimal) Phase_UOM_qty = (new Phase(), "", 0);
        public Level1()
        { 
        }
    }

    public class Level2 : DBInterface
    {
        [JsonProperty("id")]
        public int id = -1;
        [JsonProperty("level1")]
        public Level1 level1 = new Level1();
        [JsonProperty("description")]
        public string description = "";
        [JsonProperty("code")]
        public string code = "";
        [JsonIgnore]
        public (Phase, string, decimal) Phase_UOM_qty = (new Phase(), "", 0);

        public Level2()
        {
        }
    }

    public class Level3 : DBInterface
    {
        [JsonProperty("id")]
        public int id = -1;
        [JsonProperty("level2")]
        public Level2 level2 = new Level2();
        [JsonProperty("description")]
        public string description = "";
        [JsonProperty("code")]
        public string code = "";
        [JsonIgnore]
        public (Phase, string, decimal) Phase_UOM_qty = (new Phase(), "", 0);

        public Level3()
        {
        }
    }

    public class Level4 : DBInterface
    {
        [JsonProperty("id")]
        public int id = -1;
        [JsonProperty("level3")]
        public Level3 level3 = new Level3();
        [JsonProperty("description")]
        public string description = "";
        [JsonProperty("code")]
        public string code = "";
        [JsonIgnore]
        public (Phase, string, decimal) Phase_UOM_qty = (new Phase(), "", 0);

        public Level4()
        {
        }
    }
    public class Location : DBInterface
    {
        [JsonProperty("id")]
        public int id = -1;
        [JsonProperty("name")]
        public string name = "";
        [JsonProperty("code")]
        public string code = "";
        [JsonProperty("sf")]
        public decimal sf = 0;
        [JsonProperty("project")]
        public Project project = new Project();

        public Location()
        { 
        }

        public void Update()
        {
            string command = "update location set sf = " + sf.ToString() + " where id = " + id.ToString() + ";";
            SQL.QuerryUpdate(command);
        }
    }

    public class Template : DBInterface
    {
        [JsonProperty("id")]
        public int id = -1;
        [JsonProperty("code")]
        public string code = "";
        [JsonProperty("description")]
        public string description = "";
        [JsonProperty("ut")]
        public string ut = "";
        [JsonProperty("level4")]
        public Level4 level4 = new Level4();

        public Template()
        { 
        }
    }

    public class TradeCode : DBInterface
    {
        [JsonProperty("id")]
        public int id = -1;
        [JsonProperty("code")]
        public string code = "";
    }

    public class CSICode : DBInterface
    {
        [JsonProperty("id")]
        public int id = -1;
        [JsonProperty("code")]
        public string code = "";
        [JsonProperty("trade_code")]
        public TradeCode trade_code = new TradeCode();
    }

    public class Batch : DBInterface
    {
        [JsonProperty("id")]
        public int id = -1;
        [JsonProperty("active")]
        public bool active = true;
        [JsonProperty("time")]
        public DateTime trade_code = new DateTime();
        [JsonProperty("id")]
        public User user = new User();
    }

    public class Record : DBInterface
    {
        [JsonProperty("id")]
        public int id = -1;
        [JsonProperty("template")]
        public Template template = new Template();
        [JsonProperty("extension")]
        public decimal total = 0;
        [JsonProperty("qty")]
        public decimal qty = 0;
        [JsonProperty("comments")]
        public string comments = "";
        [JsonProperty("csi_code")]
        public CSICode csi_code = new CSICode();
        [JsonProperty("estimate_category")]
        public string estimate_category = "";
        [JsonProperty("location")]
        public Location location = new Location();
        [JsonProperty("phase")]
        public Phase phase = new Phase();
        [JsonIgnore]
        public decimal unit_price => qty == 0 ? 0 : total / qty;
        [JsonIgnore]
        public int project_id { get => location.project.id; set => location.project.id = value; }

        public Record()
        {
        }

        public static async void All(Action<List<Record>> result)
        {
            var all = new List<Record>();

            await Task.Run(() => 
            {
                all = SQL.GetAllRecords();
            });

            result?.Invoke(all);
        }
    }
}
