// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using Microsoft.NetCore.CSharp.Analyzers.Runtime;
using Microsoft.NetCore.VisualBasic.Analyzers.Runtime;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.Diagnostics;
using Test.Utilities;

namespace Microsoft.NetCore.Analyzers.Runtime.UnitTests
{
    public class InstantiateArgumentExceptionsCorrectlyFixerTests : CodeFixTestBase
    {
        protected override DiagnosticAnalyzer GetBasicDiagnosticAnalyzer()
        {
            return new InstantiateArgumentExceptionsCorrectlyAnalyzer();
        }

        protected override DiagnosticAnalyzer GetCSharpDiagnosticAnalyzer()
        {
            return new InstantiateArgumentExceptionsCorrectlyAnalyzer();
        }

        protected override CodeFixProvider GetBasicCodeFixProvider()
        {
            return new BasicInstantiateArgumentExceptionsCorrectlyFixer();
        }

        protected override CodeFixProvider GetCSharpCodeFixProvider()
        {
            return new CSharpInstantiateArgumentExceptionsCorrectlyFixer();
        }
    }
}