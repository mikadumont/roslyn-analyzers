﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using Test.Utilities;
using Xunit;

namespace Microsoft.NetCore.Analyzers.Security.UnitTests
{
    public class DoNotUseDeprecatedSecurityProtocolsTests : DiagnosticAnalyzerTestBase
    {
        [Fact]
        public void TestUseSsl3Diagnostic()
        {
            VerifyCSharp(@"
using System;
using System.Net;

class TestClass
{
    public void TestMethod()
    {
        var a = SecurityProtocolType.Ssl3;
    }
}",
            GetCSharpResultAt(9, 17, DoNotUseDeprecatedSecurityProtocols.Rule, "Ssl3"));
        }

        [Fact]
        public void TestUseTlsDiagnostic()
        {
            VerifyCSharp(@"
using System;
using System.Net;

class TestClass
{
    public void TestMethod()
    {
        var a = SecurityProtocolType.Tls;
    }
}",
            GetCSharpResultAt(9, 17, DoNotUseDeprecatedSecurityProtocols.Rule, "Tls"));
        }

        [Fact]
        public void TestUseTls11Diagnostic()
        {
            VerifyCSharp(@"
using System;
using System.Net;

class TestClass
{
    public void TestMethod()
    {
        var a = SecurityProtocolType.Tls11;
    }
}",
            GetCSharpResultAt(9, 17, DoNotUseDeprecatedSecurityProtocols.Rule, "Tls11"));
        }

        [Fact]
        public void TestUseSystemDefaultNoDiagnostic()
        {
            VerifyCSharp(@"
using System;
using System.Net;

class TestClass
{
    public void TestMethod()
    {
        var a = SecurityProtocolType.SystemDefault;
    }
}");
        }

        [Fact]
        public void TestUseTls12NoDiagnostic()
        {
            VerifyCSharp(@"
using System;
using System.Net;

class TestClass
{
    public void TestMethod()
    {
        var a = SecurityProtocolType.Tls12;
    }
}");
        }

        protected override DiagnosticAnalyzer GetBasicDiagnosticAnalyzer()
        {
            return new DoNotUseDeprecatedSecurityProtocols();
        }

        protected override DiagnosticAnalyzer GetCSharpDiagnosticAnalyzer()
        {
            return new DoNotUseDeprecatedSecurityProtocols();
        }
    }
}
