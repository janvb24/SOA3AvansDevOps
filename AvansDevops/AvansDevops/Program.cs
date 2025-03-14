// See https://aka.ms/new-console-template for more information

using AvansDevops.DevOps;

IPipelineBuilder pipelineBuilder = new ConcretePipelineBuilder();
Pipeline pipeline = pipelineBuilder.Build();
IPipelineVisitor visitor = new RunPipelineVisitor();
pipeline.Accept(visitor);
