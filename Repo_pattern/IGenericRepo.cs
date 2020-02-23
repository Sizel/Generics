using System;
using System.Collections.Generic;
using System.Text;

namespace Repo_pattern
{
	interface IGenericRepo<TEntity> where TEntity: class
	{
		TEntity GetById(int id);

		List<TEntity> GetAll();

		void Add(TEntity entity);

		void Remove(TEntity entity);
	}
}
