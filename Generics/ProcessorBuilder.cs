using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class ProcessorBuilder
    {
        public static ProcessorBuilder<TEngine> CreateEngine<TEngine>()
        {
            return new ProcessorBuilder<TEngine>();
        }
    }
    class ProcessorBuilder<TEngine>
    {
        public ProcessorBuilder<TEngine, TEntity> For<TEntity>()
        {
            return new ProcessorBuilder<TEngine, TEntity>();
        }
    }
    class ProcessorBuilder<TEngine, TEntity>
    {
        public Processor<TEngine, TEntity, TLogger> With<TLogger>()
        {
            return new Processor<TEngine, TEntity, TLogger>();
        }
    }
}
