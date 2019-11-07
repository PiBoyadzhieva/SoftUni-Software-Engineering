namespace P01_HospitalDatabase.Data
{
    public static class DataValidations
    {
        public static class Patient
        {
            public const int NameMaxLength = 50;
            public const int AdressMaxLength = 250;
            public const int EmailMaxLength = 80;
        }

        public static class Visitation
        {
            public const int CommentsMaxLength = 250;
        }

        public static class Diagnose
        {
            public const int DiagnoseMaxName = 50;
            public const int CommentsMaxLength = 250;
        }

        public static class Medicament
        {
            public const int MedicamentMaxName = 50;
        }

        public static class Doctor
        {
            public const int DoctorMaxName = 100;
            public const int DoctorMaxSpecialty = 100;
        }
    }
}
