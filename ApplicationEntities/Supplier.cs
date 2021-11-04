using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace ApplicationEntities
{
    public  class Supplier :TradingPartner
    {
        public int CreditBalance { get; set; }
        public string PanNo { get; set; }

        public override void SaveToFile(string filepath)
        {
           string objString =  SerializeObject<Supplier>(this);
            File.WriteAllText(filepath, objString);

        }

        public static string SerializeObject<T>( T toSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());
            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, toSerialize);
                return textWriter.ToString();
            }
        }

        public override List<string> Validate()
        {

            var errors = base.Validate();

            //Validation for CreditBalance
            if (CreditBalance > 150000)
            {
                errors.Add("Credit balance can't go beyond 150000");

            }
            //Validation for PAN

            Regex regex = new Regex("([A-Z]){5}([0-9]){4}([A-Z]){1}$");
            if (!regex.IsMatch(PanNo))
            {
                errors.Add("PAN number entered is invalid");
            }

            return errors;
        }
    }
}
