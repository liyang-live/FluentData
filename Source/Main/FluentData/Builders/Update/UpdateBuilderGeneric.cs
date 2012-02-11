﻿using System;
using System.Linq.Expressions;

namespace FluentData
{
	internal class UpdateBuilder<T> : BaseUpdateBuilder, IUpdateBuilder<T>, IInsertUpdateBuilder<T>
	{
		internal UpdateBuilder(IDbProvider provider, IDbCommand command, string name, T item)
			: base(provider, command, name)
		{
			Data.Item = item;
		}

		public IUpdateBuilder<T> Column(string columnName, object value)
		{
			Actions.ColumnValueAction(columnName, value, false);
			return this;
		}

		public IUpdateBuilder<T> AutoMap()
		{
			Actions.AutoMapColumnsAction(false);
			return this;
		}

		public IUpdateBuilder<T> IgnoreProperty(Expression<Func<T, object>> expression)
		{
			Actions.AutoMapIgnorePropertyAction(expression);
			return this;
		}

		public IUpdateBuilder<T> Column(Expression<Func<T, object>> expression)
		{
			Actions.ColumnValueAction(expression, false);
			return this;
		}

		public virtual IUpdateBuilder<T> Where(string columnName, object value)
		{
			Actions.WhereAction(columnName, value);
			return this;
		}

		public IUpdateBuilder<T> Where(Expression<Func<T, object>> expression)
		{
			Actions.WhereAction(expression);
			return this;
		}

		IInsertUpdateBuilder<T> IInsertUpdateBuilder<T>.AutoMap()
		{
			Actions.AutoMapColumnsAction(false);
			return this;
		}

		IInsertUpdateBuilder<T> IInsertUpdateBuilder<T>.IgnoreProperty(Expression<Func<T, object>> expression)
		{
			Actions.AutoMapIgnorePropertyAction(expression);
			return this;
		}

		IInsertUpdateBuilder<T> IInsertUpdateBuilder<T>.Column(string columnName, object value)
		{
			Actions.ColumnValueAction(columnName, value, false);
			return this;
		}

		IInsertUpdateBuilder<T> IInsertUpdateBuilder<T>.Column(Expression<Func<T, object>> expression)
		{
			Actions.ColumnValueAction(expression, false);
			return this;
		}
	}
}
