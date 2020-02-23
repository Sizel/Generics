using System;
using System.Collections.Generic;
using System.Text;

namespace Repo_pattern
{
	class ListGenericRepo<TEntity> : IGenericRepo<TEntity> where TEntity : Entity
	{
		private List<TEntity> _context;
		private UInt32 _lastId = 0;

		public ListGenericRepo()
		{
			_context = new List<TEntity>();
		}

		public void Add(TEntity entity)
		{
			if (_context.Contains(entity))
				throw new InvalidOperationException("This entity is already in the table");

			entity.ID = _lastId;
			_lastId++;
			_context.Add(entity);
		}

		public List<TEntity> GetAll()
		{
			return _context;
		}

		public TEntity GetById(int id)
		{
			if (id < 0 || id > _context.Count)
				throw new ArgumentOutOfRangeException("id");

			return _context.Find(e => e.ID == id);
		}

		public void Remove(TEntity entity)
		{
			_context.RemoveAll(x => x.Equals(entity));
		}
	}
}
