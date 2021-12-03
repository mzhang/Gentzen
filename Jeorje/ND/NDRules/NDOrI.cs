﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Jeorje
{
    public class NDOrI : NDRule
    {
        public static string _name = "or_i";
        public override string Name => _name;

        public sealed override string Label { get; set; }
        public sealed override AST Predicate { get; set; }
        public sealed override List<string> Requirements { get; set; }

        public NDOrI(string label, AST predicate, List<string> requirements)
        {
            Label = label;
            Requirements = requirements;
            Predicate = predicate;
        }
        //0) a premise
        //1) a | b by or_i on 0
        public override bool CheckRule(SymbolTable symbolTable, List<AST> premises)
        {
            if (Requirements.Count != 1)
            {
                throw new Exception($"{_name} must be performed on one line");
            }

            var requirement = Requirements[0];
            var requirementAST = symbolTable.Statements[requirement];
            return requirementAST.Children.Contains(Predicate);
        }
    }
}