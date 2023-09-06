using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExtractionDto.Dto.AwsModel
{
    public class AwsFileInfo
    {
        public string? Name { get; set; }  
        public string? Description { get; set; }
        public Uri? Url { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
