using TUnit.Engine.SourceGenerator.CodeGenerators;
using TUnit.Engine.SourceGenerator.Tests.Extensions;

namespace TUnit.Engine.SourceGenerator.Tests;

internal class BeforeTests : TestsBase<TestHooksGenerator>
{
    [Test]
    public Task Test() => RunTest(Path.Combine(Git.RootDirectory.FullName,
            "TUnit.TestProject",
            "BeforeTests",
            "BeforeTests.cs"),
        generatedFiles =>
        {
            Assert.That(generatedFiles.Length, Is.EqualTo(14));

            Assert.That(generatedFiles[1].IgnoreWhitespaceFormatting(), Does.Contain(
	            """
	            TestHookOrchestrator.RegisterBeforeHook<global::TUnit.TestProject.BeforeTests.Base1>(new InstanceHookMethod<global::TUnit.TestProject.BeforeTests.Base1>
	            { 
	            MethodInfo = typeof(global::TUnit.TestProject.BeforeTests.Base1).GetMethod("BeforeEach1", 0, []),
	            Body = (classInstance, testContext, cancellationToken) => AsyncConvert.Convert(() => classInstance.BeforeEach1()),
	            HookExecutor = DefaultExecutor.Instance,
	            Order = 0,
	            });
	            """.IgnoreWhitespaceFormatting()));
            
            Assert.That(generatedFiles[3].IgnoreWhitespaceFormatting(), Does.Contain(
	            """
	            TestHookOrchestrator.RegisterBeforeHook<global::TUnit.TestProject.BeforeTests.Base2>(new InstanceHookMethod<global::TUnit.TestProject.BeforeTests.Base2>
	            { 
	            MethodInfo = typeof(global::TUnit.TestProject.BeforeTests.Base2).GetMethod("BeforeEach2", 0, []),
	            Body = (classInstance, testContext, cancellationToken) => AsyncConvert.Convert(() => classInstance.BeforeEach2()),
	            HookExecutor = DefaultExecutor.Instance,
	            Order = 0,
	            });
	            """.IgnoreWhitespaceFormatting()));
            
            Assert.That(generatedFiles[5].IgnoreWhitespaceFormatting(), Does.Contain(
	            """
	            TestHookOrchestrator.RegisterBeforeHook<global::TUnit.TestProject.BeforeTests.Base3>(new InstanceHookMethod<global::TUnit.TestProject.BeforeTests.Base3>
	            { 
	            MethodInfo = typeof(global::TUnit.TestProject.BeforeTests.Base3).GetMethod("BeforeEach3", 0, []),
	            Body = (classInstance, testContext, cancellationToken) => AsyncConvert.Convert(() => classInstance.BeforeEach3()),
	            HookExecutor = DefaultExecutor.Instance,
	            Order = 0,
	            });
	            """.IgnoreWhitespaceFormatting()));
            
            Assert.That(generatedFiles[10].IgnoreWhitespaceFormatting(), Does.Contain(
	            """
		            TestHookOrchestrator.RegisterBeforeHook<global::TUnit.TestProject.BeforeTests.SetupTests>(new InstanceHookMethod<global::TUnit.TestProject.BeforeTests.SetupTests>
		            { 
		            MethodInfo = typeof(global::TUnit.TestProject.BeforeTests.SetupTests).GetMethod("Setup", 0, []),
		            Body = (classInstance, testContext, cancellationToken) => AsyncConvert.Convert(() => classInstance.Setup()),
		            HookExecutor = DefaultExecutor.Instance,
		            Order = 0,
		            });
		            """.IgnoreWhitespaceFormatting()));
            
            Assert.That(generatedFiles[11].IgnoreWhitespaceFormatting(), Does.Contain(
	            """
		            TestHookOrchestrator.RegisterBeforeHook<global::TUnit.TestProject.BeforeTests.SetupTests>(new InstanceHookMethod<global::TUnit.TestProject.BeforeTests.SetupTests>
		            { 
		            MethodInfo = typeof(global::TUnit.TestProject.BeforeTests.SetupTests).GetMethod("Setup", 0, [typeof(global::System.Threading.CancellationToken)]),
		            Body = (classInstance, testContext, cancellationToken) => AsyncConvert.Convert(() => classInstance.Setup(cancellationToken)),
		            HookExecutor = DefaultExecutor.Instance,
		            Order = 0,
		            });
		            """.IgnoreWhitespaceFormatting()));
            
            Assert.That(generatedFiles[12].IgnoreWhitespaceFormatting(), Does.Contain(
	            """
		            TestHookOrchestrator.RegisterBeforeHook<global::TUnit.TestProject.BeforeTests.SetupTests>(new InstanceHookMethod<global::TUnit.TestProject.BeforeTests.SetupTests>
		            { 
		            MethodInfo = typeof(global::TUnit.TestProject.BeforeTests.SetupTests).GetMethod("SetupWithContext", 0, [typeof(global::TUnit.Core.TestContext)]),
		            Body = (classInstance, testContext, cancellationToken) => AsyncConvert.Convert(() => classInstance.SetupWithContext(testContext)),
		            HookExecutor = DefaultExecutor.Instance,
		            Order = 0,
		            });
		            """.IgnoreWhitespaceFormatting()));
            
            Assert.That(generatedFiles[13].IgnoreWhitespaceFormatting(), Does.Contain(
	            """
		            TestHookOrchestrator.RegisterBeforeHook<global::TUnit.TestProject.BeforeTests.SetupTests>(new InstanceHookMethod<global::TUnit.TestProject.BeforeTests.SetupTests>
		            { 
		            MethodInfo = typeof(global::TUnit.TestProject.BeforeTests.SetupTests).GetMethod("SetupWithContext", 0, [typeof(global::TUnit.Core.TestContext), typeof(global::System.Threading.CancellationToken)]),
		            Body = (classInstance, testContext, cancellationToken) => AsyncConvert.Convert(() => classInstance.SetupWithContext(testContext, cancellationToken)),
		            HookExecutor = DefaultExecutor.Instance,
		            Order = 0,
		            });
		            """.IgnoreWhitespaceFormatting()));
        });
}