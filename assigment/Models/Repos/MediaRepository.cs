using assignment.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
  public  class MediaRepository : Repository<Media> ,IMediaRepositoryInterface
    {
        private ExDBContext _myDbContext;
        public MediaRepository(ExDBContext context) : base(context)
        {
            _myDbContext = context;
        }
        public Media AddMedia(Media Media)
        {
            _myDbContext.Medias.Add(Media);
            _myDbContext.SaveChanges();
            return Media;
        }



        public Media GetMedia(int Id)
        {
            return _myDbContext.Medias.FirstOrDefault(x => x.Media_id == Id);
        }

        public List<Media> GetMedias()
        {
            return _myDbContext.Medias.Include(h => h.Category).ToList();
        }

        public void UpdateMedia(Media Media)
        {
            _myDbContext.Medias.Update(Media);
            _myDbContext.SaveChanges();
        }

        public async Task PatchMedia(int productId,JsonPatchDocument Media)
        {
            var product = await _myDbContext.Medias.FindAsync(productId);
            if (product != null)
            {
                Media.ApplyTo(product);
                await _myDbContext.SaveChangesAsync();
            }
        }

        public Media Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Media> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Media> Find(Expression<Func<Media, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Media SingleOrDefault(Expression<Func<Media, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Media Add(Media entity)
        {
            _myDbContext.Medias.Add(entity);
            _myDbContext.SaveChanges();
            return entity;
        }

        public void AddRange(IEnumerable<Media> entities)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            var hotel = _myDbContext.Medias.FirstOrDefault(x => x.Media_id == id);
            if (hotel != null)
            {
                _myDbContext.Remove(hotel);
                _myDbContext.SaveChanges();
            }
        }

        public void RemoveRange(IEnumerable<Media> entities)
        {
            _myDbContext.RemoveRange(entities);
        }

        public List<Media> GetUserMedias(string userId)
        {
         return   _myDbContext.Medias.Where(m => m.Media_User_id == userId).ToList();
        }
    }
}
