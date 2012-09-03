﻿using System;
using System.Collections.Generic;

namespace FluentData
{
	internal class GenericQueryHandler<TEntity>
	{
		internal TList ExecuteListReader<TList>(
									DbCommandData data,
									Action<IDataReader, TEntity> customMapperReader
					)
			where TList : IList<TEntity>
		{
			var items = (TList) data.ContextData.EntityFactory.Create(typeof(TList));

			var autoMapper = new AutoMapper<TEntity>(data, typeof(TEntity));

			while (data.Reader.Read())
			{
				var item = (TEntity) data.ContextData.EntityFactory.Create(typeof(TEntity));

				if (customMapperReader == null)
					autoMapper.AutoMap(item);
				else
					customMapperReader(data.Reader, item);

				items.Add(item);
			}

			return items;
		}

		internal TEntity ExecuteSingle(DbCommandData data,
										Action<IDataReader, TEntity> customMapper)
		{
			AutoMapper<TEntity> autoMapper = null;

			autoMapper = new AutoMapper<TEntity>(data, typeof(TEntity));

			var item = default(TEntity);

			if (data.Reader.Read())
			{
				item = (TEntity) data.ContextData.EntityFactory.Create(typeof(TEntity));

				if (customMapper == null)
					autoMapper.AutoMap(item);
				else
					customMapper(data.Reader, item);
			}

			return item;
		}
	}
}
