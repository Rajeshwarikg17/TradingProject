using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;


namespace ApplicationEntities
{
   [Serializable]
    public class Customer : TradingPartner
    {
        public int CreditLimit { get; set; }
        public string EmailId { get; set; }

        public override void SaveToFile(string filepath)
        {
            //MemoryStream memorystream = new MemoryStream();
            //BinaryFormatter bf = new BinaryFormatter();
            //bf.Serialize(memorystream, this);
            //byte[] yourBytesToDb = memorystream.ToArray();
            Serialize(this, filepath);

        }

        //Serializing the List  
        public static void Serialize(Customer customer, String filename)
        {
            //Create the stream to add object into it.  
            System.IO.Stream ms = File.OpenWrite(filename);
            //Format the object as Binary  

            BinaryFormatter formatter = new BinaryFormatter();
            //It serialize the employee object  
            formatter.Serialize(ms, customer);
            ms.Flush();
            ms.Close();
            ms.Dispose();
        }


        public override List<string> Validate()
        {
            var errors = base.Validate();

            //Validation for Credit Limit

            if (CreditLimit > 50000)
            {
                errors.Add("Credit Limit can't go beyond 50000");

            }
            //Validation for email Id
            bool isEmail = Regex.IsMatch(EmailId, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            if (!isEmail)
            {
                errors.Add("Invalid Email Id");
            }

            return errors;
        }
    }
}
