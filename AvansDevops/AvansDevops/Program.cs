// See https://aka.ms/new-console-template for more information

using AvansDevops.DevOps;

IPipelineBuilder builder = new ConcretePipelineBuilder();
Pipeline pipeline = builder.Build();
IPipelineVisitor visitor = new RunPipelineVisitor();
pipeline.Accept(visitor);
