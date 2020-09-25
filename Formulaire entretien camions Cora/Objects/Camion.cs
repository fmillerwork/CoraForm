using System.Xml.Serialization;

namespace Formulaire_entretien_camions_Cora.Objects
{
    public class Camion
    {
        [XmlAttribute(AttributeName = "Immatriculation")]
        public string Immatriculation { get; set; }

        [XmlAttribute(AttributeName = "Type")]
        public string Type { get; set; }

        public Camion(string immatriculation, string type)
        {
            Immatriculation = immatriculation;
            Type = type;
        }

        public Camion()
        {

        }
    }
}
