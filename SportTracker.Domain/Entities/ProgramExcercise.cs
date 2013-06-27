namespace SportTracker.Domain.Entities
{
   public partial class ProgramExcercise
    {
        public int ProgramExcerciseId { get; set; }
        public string Day { get; set; }
        public short Order { get; set; }
        public string SetCounts { get; set; }
        public string RepsScheme { get; set; }
        public int ProgramProgramId { get; set; }
    
        public virtual Excercise Excercise { get; set; }
        public virtual Program Program { get; set; }
    }
}
