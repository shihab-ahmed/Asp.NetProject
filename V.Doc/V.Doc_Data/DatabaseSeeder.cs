using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Doc_Entity;
using V.Doc_Utilities;

namespace V.Doc_Data
{
    public class DatabaseSeeder : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            AddDefaultAdmin(context);
            AddDefaultData(context);
            base.Seed(context);
        }

        private void AddDefaultAdmin(DatabaseContext context)
        {
            User user = new User()
            {
                FirstName = "System",
                LastName = "Admin",
                UserName = "Admin",
                Email = "Admin@Admin.Com",
                Password = "Admin",
                Birthdate = DateTime.Now,
                Age = 0,
                Gender = "Male",
                Type = Enum_UserType.Admin.ToString(),
                ProfilePicture = "~/UploadedFiles/Images/DefaultAdminPic.jpg"
            };
            context.Users.Add(user);
            context.SaveChanges();
        }

        private void AddDefaultData(DatabaseContext context)
        {
            Specialist Cardiologist = new Specialist();
            Specialist Dermatologist = new Specialist();
            Specialist Neurologist = new Specialist();
            Specialist Allergist = new Specialist();
            Specialist Gastroenterologist = new Specialist();


            Symptom ChestPain = new Symptom();
            Symptom Numb = new Symptom();
            Symptom WhiteHead = new Symptom();
            Symptom BlackHead = new Symptom();
            Symptom ServerPain = new Symptom();
            Symptom ShortnessOfBreath = new Symptom();
            Symptom Coughfing = new Symptom();
            Symptom StomacPain = new Symptom();


            Disease Cardiovascular = new Disease();
            Disease Acne = new Disease();
            Disease Amyotrophy = new Disease();
            Disease Asthma = new Disease();
            Disease Gastritis = new Disease();


            Medicine Napa = new Medicine();
            Medicine Asparin = new Medicine();
            Medicine Ativan = new Medicine();
            Medicine Ace = new Medicine();
            Medicine Deslor = new Medicine();
            Medicine XincB = new Medicine();


            //Specialist
            Cardiologist.Type = "Gastroenterologist";
            Dermatologist.Type = "Dermatologist";
            Neurologist.Type = "Neurologist";
            Allergist.Type = "Allergist";
            Gastroenterologist.Type = "Gastroenterologist";

            Cardiologist.Symptoms = new List<Symptom>() { ChestPain,Numb};
            Dermatologist.Symptoms = new List<Symptom>() { WhiteHead, BlackHead };
            Neurologist.Symptoms = new List<Symptom>() { ServerPain };
            Allergist.Symptoms = new List<Symptom>() { Coughfing, ShortnessOfBreath };
            Gastroenterologist.Symptoms = new List<Symptom>() { StomacPain};



            //Symptoms
            ChestPain.Name = "Chest Pain";
            Numb.Name = "Numb";
            WhiteHead.Name = "White Head";
            BlackHead.Name = "Black Head";
            ServerPain.Name = "Server Pain";
            ShortnessOfBreath.Name = "Shortness Of Breath";
            Coughfing.Name = "Coughfing";
            StomacPain.Name = "Stomac Pain";

            ChestPain.Specialists = new List<Specialist>() { Cardiologist };
            Numb.Specialists = new List<Specialist>() { Cardiologist };
            WhiteHead.Specialists = new List<Specialist>() { Dermatologist };
            BlackHead.Specialists = new List<Specialist>() { Dermatologist };
            ServerPain.Specialists = new List<Specialist>() { Neurologist };
            ShortnessOfBreath.Specialists = new List<Specialist>() { Allergist };
            Coughfing.Specialists = new List<Specialist>() { Allergist };
            StomacPain.Specialists = new List<Specialist>() { Gastroenterologist };

            ChestPain.Diseases = new List<Disease>() { Cardiovascular };
            Numb.Diseases = new List<Disease>() { Cardiovascular };
            WhiteHead.Diseases = new List<Disease>() { Acne };
            BlackHead.Diseases = new List<Disease>() { Acne };
            ServerPain.Diseases = new List<Disease>() { Amyotrophy };
            ShortnessOfBreath.Diseases = new List<Disease>() { Asthma };
            Coughfing.Diseases = new List<Disease>() { Asthma };
            StomacPain.Diseases = new List<Disease>() { Gastritis };




            //Diseases
            Cardiovascular.Name = "Cardiovascular";
            Acne.Name = "Acne";
            Amyotrophy.Name = "Amyotrophy";
            Asthma.Name = "Asthma";
            Gastritis.Name = "Gastritis";

            Cardiovascular.Symptoms = new List<Symptom>() { ChestPain, Numb };
            Acne.Symptoms = new List<Symptom>() { WhiteHead, BlackHead };
            Amyotrophy.Symptoms = new List<Symptom>() { ServerPain };
            Asthma.Symptoms = new List<Symptom>() { Coughfing, ShortnessOfBreath };
            Gastritis.Symptoms = new List<Symptom>() { StomacPain };

            Cardiovascular.Medicines = new List<Medicine>() { XincB,Asparin};
            Acne.Medicines = new List<Medicine>() { XincB, Ativan };
            Amyotrophy.Medicines = new List<Medicine>() { XincB, Asparin };
            Asthma.Medicines = new List<Medicine>() { Napa, Ace };
            Gastritis.Medicines = new List<Medicine>() { Deslor, Asparin };




            //Medicine
            Napa.Name = "Napa";
            Asparin.Name = "Asparin";
            Ace.Name = "Ace";
            Deslor.Name = "Deslor";
            Ativan.Name = "Ativan";
            XincB.Name = "XincB";

            Napa.Type = "Tablet";
            Asparin.Type = "Tablet";
            Ace.Type = "Tablet";
            Deslor.Type = "Tablet";
            Ativan.Type = "Tablet";
            XincB.Type = "Tablet";

            Napa.Diseases = new List<Disease>() {Cardiovascular};
            Asparin.Diseases = new List<Disease>() { Acne};
            Ace.Diseases = new List<Disease>() {Acne,Amyotrophy };
            Deslor.Diseases = new List<Disease>() { Asthma};
            Ativan.Diseases = new List<Disease>() {Asthma,Gastritis };
            XincB.Diseases = new List<Disease>() { Amyotrophy,Gastritis,Cardiovascular};


            context.Specialists.Add(Cardiologist);
            context.Specialists.Add(Dermatologist);
            context.Specialists.Add(Neurologist);
            context.Specialists.Add(Allergist);
            context.Specialists.Add(Gastroenterologist);

            context.Symptoms.Add(ChestPain);
            context.Symptoms.Add(Numb);
            context.Symptoms.Add(WhiteHead);
            context.Symptoms.Add(BlackHead);
            context.Symptoms.Add(ServerPain);
            context.Symptoms.Add(ShortnessOfBreath);
            context.Symptoms.Add(Coughfing);
            context.Symptoms.Add(StomacPain);

            context.Diseases.Add(Cardiovascular);
            context.Diseases.Add(Acne);
            context.Diseases.Add(Amyotrophy);
            context.Diseases.Add(Asthma);
            context.Diseases.Add(Gastritis);


            context.Medicines.Add(Napa);
            context.Medicines.Add(Asparin);
            context.Medicines.Add(Ativan);
            context.Medicines.Add(Ace);
            context.Medicines.Add(Deslor);
            context.Medicines.Add(XincB);

            context.SaveChanges();
        }
    }
}
