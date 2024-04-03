using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Budget.MODEL.Dto
{
    //[NotMapped]
    public class Solde : SoldeDto
    {
        public Select Account { get; set; }
        public DateTime DateMax { get; set; }
    }

    //[NotMapped]
    public class SoldeDto
    {
        public int IdAccount { get; set; }
        private double _credit;
        //[Key]
        public double Credit
        {
            get => Math.Round(_credit, 2);
            set => _credit = Math.Round(value, 2);
        }

        private double _debit;
        public double Debit
        {
            get => Math.Round(_debit, 2);
            set => _debit = Math.Round(value, 2);
        }

        private double _total;
        public double Total
        {
            get => Math.Round(_total, 2);
            set => _total = Math.Round(value, 2);
        }
        private double _solde;
        public double Solde
        {
            get => Math.Round(_solde, 2);
            set => _solde = Math.Round(value, 2);
        }

    }
}
