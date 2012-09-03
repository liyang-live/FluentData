﻿using System;

namespace FluentData
{
	internal class QuerySingleComplexHandler<TEntity>
	{
		internal TEntity ExecuteSingleComplex(DbCommandData data,
			Func<IDataReader, TEntity> customMapperReader)
		{
			var item = default(TEntity);

			if (data.Reader.Read())
				item = customMapperReader(data.Reader);

			return item;
		}
	}
}
