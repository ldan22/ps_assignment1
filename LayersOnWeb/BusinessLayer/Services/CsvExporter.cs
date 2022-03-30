using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Contracts;


namespace BusinessLayer
{
    public class CsvExporter<T> : FileExporter<T>
    {
        public string export(List<T> exportData, string path)
        {
            var lines = new List<string>();
            IEnumerable<PropertyDescriptor> props = TypeDescriptor.GetProperties(typeof(T)).OfType<PropertyDescriptor>();
            var header = string.Join(",", props.ToList().Select(x => x.Name));
            lines.Add(header);
            var valueLines = exportData.Select(row => string.Join(",", header.Split(',').Select(a => row.GetType().GetProperty(a).GetValue(row, null))));
            lines.AddRange(valueLines);
            FileInfo file = new FileInfo(path);
            file.Directory.Create();
            File.WriteAllLines(path, lines.ToArray());
            return path;
        } 
    }
}
