//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DeansOffice
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student
    {
        public int IdStudent { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Pesel { get; set; }
        public string NumerPaszportu { get; set; }
        public string Obywatelstwo { get; set; }
        public string NumerIndeksu { get; set; }
        public string RokZapisania { get; set; }
        public Nullable<int> IdSemestr { get; set; }
    
        public virtual Semestr Semestr { get; set; }
    }
}
