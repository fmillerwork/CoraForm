using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace Formulaire_entretien_camions_Cora.Objects
{
    public class Session
    {
        private const string FILENAME = "session.xml";

        //private static string _applicationDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        //private static string _applicationDataPath = "S:/Bureau";
        private static string _applicationPath = "xml";

        private readonly XmlWriterSettings _xmlWriterSettings;

        /// <summary>
        /// Chemin d'accès et nom du fichier représentant la session.
        /// </summary>
        public static string FileName { get; } = Path.Combine(_applicationPath, FILENAME);

        public List<Camion> Camions { get; set; }

        public Session()
        {
            Camions = new List<Camion>();
            _xmlWriterSettings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = ("\t"),
                OmitXmlDeclaration = true
            };

            if (!Directory.Exists(_applicationPath))
            {
                Directory.CreateDirectory(_applicationPath);
            }
        }
        /// <summary>
        /// Charge les camions depuis un fichier xml. Retourne une Session.
        /// </summary>
        public static Session Load()
        {
            var session = new Session();

            if (File.Exists(FileName) && new FileInfo(FileName).Length != 0) // fichier existe et non vide
            {
                var serializer = new XmlSerializer(typeof(Session));
                var streamReader = new StreamReader(FileName);

                try
                {
                    session = (Session) serializer.Deserialize(streamReader);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Une erreur s'est produite : " + ex.Message);
                }
            }
            return session;
        }

        /// <summary>
        /// Sauvegarde les camions dans un fichier xml
        /// </summary>
        public void Save()
        {
            var emptyNamespace = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(typeof(Session));
            using (XmlWriter writer = XmlWriter.Create(FileName, _xmlWriterSettings))
            {
                serializer.Serialize(writer, this, emptyNamespace);
            }
        }
    }
}
