using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace QuizAPI.Models
{
    public class Participant
    {
        [Key]
        public int ParticipantId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Password { get; set; }

        public int Score { get; set; }

        //public int TimeTaken { get; set; }
    }

    public class _Participant
    {
        public int ParticipantId { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public int Score { get; set; }

        //public int TimeTaken { get; set; }

    }


}


