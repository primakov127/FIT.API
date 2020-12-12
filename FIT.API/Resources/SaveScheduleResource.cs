using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FIT.API.Resources
{
    public class SaveScheduleResource
    {
        [Required]
        public int SubjectId { get; set; }

        [Required]
        [MaxLength(450)]
        public string TeacherId { get; set; }

        [Required]
        public int RoomId { get; set; }

        [Range(0, 2)]
        public int Week { get; set; }

        [Required]
        [Range(1, 7)]
        public int WeekDay { get; set; }

        [Required]
        [Range(1, 7)]
        public int LessonNum { get; set; }

        [Required]
        [Range(1, 4)]
        public int Course { get; set; }

        [Required]
        [Range(1, 13)]
        public int Group { get; set; }

        [Required]
        [Range(1, 2)]
        public int SubGroup { get; set; }
    }
}
