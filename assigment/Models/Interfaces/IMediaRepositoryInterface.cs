using Microsoft.AspNetCore.JsonPatch;
using Model;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
 public   interface IMediaRepositoryInterface:IRepository<Media>
    {
       

        List<Media> GetMedias();
        List<Media> GetUserMedias(string userId);

        void UpdateMedia(Media Media);


        Media GetMedia(int Id);
         Task PatchMedia(int productId, JsonPatchDocument Media);
    }
}
