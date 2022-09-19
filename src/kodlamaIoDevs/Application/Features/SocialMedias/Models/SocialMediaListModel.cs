using Application.Features.SocialMedias.Dtos;
using Application.Features.Technologies.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedias.Models
{
    public class SocialMediaListModel:BasePageableModel
    {
        public IList<SocialMediaListDto> Items { get; set; }
    }
}
