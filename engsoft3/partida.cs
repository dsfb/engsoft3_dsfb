//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace engsoft3
{
    using System;
    using System.Collections.Generic;
    
    public partial class partida
    {
        public int ID { get; set; }
        public int player1 { get; set; }
        public int player2 { get; set; }
        public string resultado { get; set; }
        public int estado { get; set; }
    
        public virtual player player { get; set; }
        public virtual player player3 { get; set; }
    }
}
