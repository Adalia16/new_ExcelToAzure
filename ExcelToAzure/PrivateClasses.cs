using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Reflection;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Drawing;

namespace ExcelToAzure
{
    public static class PrivateClasses
    {
        public static bool doFirst<T> (this IEnumerable<T> array, Action<T> action)
        {
            if (array == null || !array.Any())
                return false;
             action?.SafeInvoke(array.First());
            return true;
        }
        public static bool doFirst<T>(this Collection<T> array, Action<T> action)
        {
            if (array == null || !array.Any())
                return false;
            action?.SafeInvoke(array.First());
            return true;
        }

        public static void SafeInvoke(this System.Action action)
        {
            Form1.Main.SafeInvoke(x => action?.Invoke());
        }
        public static void SafeInvoke<T>(this System.Action<T> action, T arg)
        {
            Form1.Main.SafeInvoke(x => action?.Invoke(arg));
        }

        public static void SafeInvoke<T>(this T isi, Action<T> call) where T : ISynchronizeInvoke
        {
            if (isi.InvokeRequired) isi.BeginInvoke(call, new object[] { isi });
            else
                call(isi);
        }

        public static T Copy<T>(this T controlToClone) where T : Control
        {
            PropertyInfo[] controlProperties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            T instance = Activator.CreateInstance<T>();

            foreach (PropertyInfo propInfo in controlProperties)
            {
                if (propInfo.CanWrite)
                {
                    if (propInfo.Name != "WindowTarget")
                        propInfo.SetValue(instance, propInfo.GetValue(controlToClone, null), null);
                }
            }

            return instance;
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        public static void RemoveBy<T>(this List<T> myList, Func<T, bool> comparison) where T : class
        {
            var toBeRemoved = new List<T>();
            foreach (T element in myList)
            {
                if (comparison.Invoke(element))
                {
                    toBeRemoved.Add(element);
                }
            }
            foreach (T element in toBeRemoved)
            {
                myList.Remove(element);
            }
        }

        public static List<T> Merge<T>(this List<List<T>> list)
        {
            var merged = new List<T>();
            list.ForEach(l => merged.AddRange(l));
            return merged;
        }

        public static T Clone<T>(this T controlToClone) where T : Control
        {
            T instance = DeepClone(controlToClone);

            return instance;
        }

        private static dynamic DeepClone(dynamic ob1)
        {
            dynamic ob2 = null;
            if (ob1.GetType().IsSerializable && !ob1.GetType().IsArray)
            {
                if (ob1 != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        formatter.Serialize(ms, ob1);
                        ms.Position = 0;
                        ob2 = formatter.Deserialize(ms);
                    }
                }
            }
            else
            {
                if (ob1.GetType().IsArray)
                {
                    var r1 = ob1.Rank;
                    object[] d1 = new object[r1];
                    long[] V1 = new long[r1];
                    for (int i = 0; i < r1; i++)
                    {
                        V1[i] = 0;
                        d1[i] = ob1.GetUpperBound(i) + 1;
                    }
                    ob2 = Activator.CreateInstance(ob1.GetType(), d1);
                    for (long i = 0; i <= ob2.Length; i++)
                    {
                        ob2.SetValue(DeepClone(ob1.GetValue(V1)), V1);
                        for (int j = 0; j <= V1.GetUpperBound(0); j++)
                        {
                            if (V1[j] < ob2.GetUpperBound(j))
                            {
                                V1[j]++;
                                break;
                            }
                            else
                            {
                                V1[j] = 0;
                            }
                        }
                    }
                }
                else
                {
                    PropertyInfo[] P1 = ob1.GetType().GetProperties();
                    ob2 = Activator.CreateInstance(ob1.GetType());
                    foreach (PropertyInfo p1 in P1)
                    {
                        try
                        {
                            if (p1.PropertyType.GetInterface("System.Collections.ICollection", true) != null)
                            {
                                dynamic V2 = p1.GetValue(ob1) as IEnumerable;
                                MethodInfo gm1 = p1.PropertyType.GetMethods().Where(m => m.Name == "Add").Where(p => p.GetParameters().Count() == 1).First(f => V2[0].GetType().IsSubclassOf(f.GetParameters()[0].ParameterType) || f.GetParameters()[0].ParameterType == V2[0].GetType());
                                if (V2[0].GetType().IsSubclassOf(gm1.GetParameters()[0].ParameterType) || gm1.GetParameters()[0].ParameterType == V2[0].GetType())
                                {
                                    for (int i = 0; i < V2.Count; i++)
                                    {
                                        dynamic V3 = DeepClone(V2[i]);
                                        gm1.Invoke(p1.GetValue(ob2), new[] { V3 });
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    foreach (PropertyInfo p1 in P1)
                    {
                        try
                        {
                            if (p1.PropertyType.IsSerializable && p1.CanWrite)
                            {
                                var v2 = p1.GetValue(ob1);
                                p1.SetValue(ob2, v2);
                            }
                            if (!p1.PropertyType.IsSerializable && p1.CanWrite)
                            {
                                dynamic V2 = p1.GetValue(ob1);
                                if (p1.PropertyType.GetMethod("Clone") != null)
                                {
                                    dynamic v1 = V2.Clone();
                                    p1.SetValue(ob2, v1);
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
            }
            return ob2;
        }

        public static T New<T>(this T obj) where T : new()
        {
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(obj));
        }

        public static string ToJSONString<T>(this T obj) where T : DBInterface
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static string ToJSONCleanString<T>(this T obj) where T : DBInterface
        {
            return JsonConvert.SerializeObject(obj).RemoveJSONCharacters();
        }

        public static string RemoveJSONCharacters(this string text)
        {
            return text.Replace("{", "").Replace("}", "").Replace(":", " ").Replace("\"", " ").Replace("[", "").Replace("]", "").Trim();
        }

        public static bool EqualTo<T>(this T original, T comparer) where T : DBInterface
        {
            return JsonConvert.SerializeObject(original) == JsonConvert.SerializeObject(comparer);
        }

        public static List<Control> All(this Control control)
        {
            var all = new List<Control>();
            control.Controls.Cast<Control>().ToList().ForEach(x => all.AddRange(x.All()));
            all.Add(control);
            return all;
        }

        public static T FindLink<T>(this List<Control> all, T type, string name) where T : Control, new()
        {
            type = all.Find(x => x.GetType() == typeof(T) && x.Name == name) as T ?? new T();
            return type;
        }

        public static T As<T> (this object obj) where T : Control
        {
            return obj as T;
        }

        public static string NumbersOnly(this string text, bool dot = false)
        {
            var res = new string((text.ToList().FindAll(x => char.IsNumber(x) || x == '.') ?? new List<char>()).ToArray());
            if (dot)
            {
                string clean = "";
                foreach (char c in res)
                {
                    if (c != '.' || !clean.Contains('.'))
                        clean += c;
                }
                if (clean.Any() && clean[0] == '.')
                    clean = "0" + clean;
                return clean;
            }
            else
            {
                return res.Replace(".", "");
            }
        }

        public static string NumbersOnly(this Control control, bool dot = false) => NumbersOnly(control.Text, dot);

        public static decimal ToDecimal(this string text)
        {
            var res = text.NumbersOnly(true);
            return res.Any() ? decimal.Parse(res) : 0;
        }

        public static decimal ToDecimal(this Control control) => ToDecimal(control.Text);

        public static int ToInt(this string text) => (int)text.ToDecimal();
        public static int ToInt(this Control text) => (int)text.ToDecimal();

        public static void Flash(this Form form, int interval, int times, params Control[] controls)
        {
            var labels = controls.ToList().Select(label => (label, label.ForeColor, label.AccessibleDescription)).ToList().FindAll(l => l.label.AccessibleDescription != "animating");
            labels.ForEach(l => l.label.AccessibleDescription = "animating");
            form.SafeInvoke(async f =>
            {
                for(int i = 0; i < times; i++)
                {
                    labels.ForEach(x => x.label.ForeColor = Color.White);
                    await Task.Delay(interval / 2);
                    labels.ForEach(x => x.label.ForeColor = x.ForeColor);
                    await Task.Delay(interval / 2);
                }
                labels.ForEach(l => l.label.AccessibleDescription = l.AccessibleDescription);
            });
        }
    }
}
