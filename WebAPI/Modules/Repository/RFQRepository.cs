using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using WebAPI.Models;
using WebAPI.Modules.Service;

namespace WebAPI.Modules.Repository
{
    public interface IRFQRepository : IScopedService
    {
        List<RequestForQuotation> GetAll();

        RequestForQuotation GetItemById(Guid id);
    }

    public class RFQRepository : Repository<RequestForQuotation>, IRFQRepository
    {
        public RFQRepository(RFQDBContext readContext, RFQDBContext writeContext) : base(readContext, writeContext)
        {
        }

        public List<RequestForQuotation> GetAll()
        {
            IQueryable<RequestForQuotation> requestForQuotations = readContext.RequestForQuotations.AsNoTracking();
            // requestForQuotations = Apply(Users, SearchUserEntity);
            return requestForQuotations.ToList();
        }

        public RequestForQuotation GetItemById(Guid id)
        {
            RequestForQuotation requestForQuotations = readContext.RequestForQuotations.Where(x => x.Id == id).AsNoTracking().FirstOrDefault();
            // requestForQuotations = Apply(Users, SearchUserEntity);
            return requestForQuotations;
        }
    }

    public abstract class Repository<T> where T : Base
    {
        protected readonly RFQDBContext readContext;
        protected readonly RFQDBContext writeContext;
        public Repository(RFQDBContext readContext, RFQDBContext writeContext)
        {
            this.readContext = readContext;
            this.writeContext = writeContext;
        }
        public T Find(Guid Id)
        {
            return readContext.Set<T>().Find(Id);
        }

        protected IQueryable<T> SkipAndTake(IQueryable<T> source, FilterEntity FilterEntity)
        {
            source = source.Skip(FilterEntity.Skip).Take(FilterEntity.Take);
            return source;
        }
    }
    public class Cache<T>
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public T data { get; set; }
    }

    public abstract class Base : IEquatable<Base>
    {
        internal abstract string _Id { get; }
        [NotMapped]
        public bool Deleted { get; set; }
        public Base() { }
        public Base(object obj)
        {
            // Common.Copy<object>(obj, this);
        }
        public bool Equals(Base other)
        {
            if (other == null) return false;
            else return other._Id.Equals(this._Id);
        }
    }

    public interface IFilterEntity
    {
        int Take { get; set; }
        int Skip { get; set; }
        string SortBy { get; set; }
        SortType? SortType { get; set; }
    }

    public class FilterEntity : IFilterEntity
    {
        public Guid? CurrentUserId;
        public int Take { get; set; }
        public int Skip { get; set; }
        public string SortBy { get; set; }
        public SortType? SortType { get; set; }
        public FilterEntity()
        {
            if (Take == 0) Take = int.MaxValue;
            if (Skip == 0) Skip = 0;
            if (string.IsNullOrEmpty(SortBy)) SortBy = "CX";
            // if (!SortType.HasValue) this.SortType = API.SortType.ASC;
        }
    }

    public enum SortType
    {
        NONE = 0,
        DESC = 1,
        ASC = 2
    }
}
