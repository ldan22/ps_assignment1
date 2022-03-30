using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using BusinessLayer.Contracts;


namespace BusinessLayer
{
    public class XmlExporter<T> : FileExporter<T>
    {
        public string export(List<T> exportData, string path)
        {
            TextWriter txtWriter = new StreamWriter(path);
            XmlSerializer xs = new XmlSerializer(typeof(List<T>));
            xs.Serialize(txtWriter, exportData);
            
            return path;
        }
    }
}
