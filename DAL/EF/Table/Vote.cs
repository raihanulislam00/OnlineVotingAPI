using DAL.EF.TableModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Table
{
    public class Vote
    {
        public int Id { get; set; }

        // Foreign Key for Poll
        [ForeignKey("Poll")]
        public int PollId { get; set; }
        public virtual Poll Poll { get; set; }

        // Foreign Key for Option
        [ForeignKey("Option")]
        public int OptionId { get; set; }
        public virtual Option Option { get; set; }  // Fixed: Should be Option, not Poll

        // Foreign Key for User (make nullable for anonymous votes)
        [ForeignKey("User")]
        public int? UserId { get; set; }  // Fixed: Made nullable to match DTO
        public virtual User User { get; set; }
    }
}