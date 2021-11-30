namespace ApplicationProcess.Service
{
    public class ApplicantDto
    {
        public int Id { get; set; }
        //Name(string )
        public string Name { get; set; }
        //FamilyName(string )
        public string FamilyName { get; set; }
        //Address(string )
        public string Address { get; set; }
        //CountryOfOrigin(string )
        public string CountryOfOrigign { get; set; }
        //EMailAdress(string )
        public string EMailAddress { get; set; }
        //Age(int)
        public int Age { get; set; }
        //Hired(bool) – false if not provided.
        public bool Hired { get; set; }
    }
}
