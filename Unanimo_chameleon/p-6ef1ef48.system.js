System.register([],(function(e){"use strict";return{execute:function(){e("default",r);var n="[0-9](_*[0-9])*",a="\\.(".concat(n,")"),s="[0-9a-fA-F](_*[0-9a-fA-F])*",t={className:"number",variants:[{begin:"(\\b(".concat(n,")((").concat(a,")|\\.)?|(").concat(a,"))[eE][+-]?(").concat(n,")[fFdD]?\\b")},{begin:"\\b(".concat(n,")((").concat(a,")[fFdD]?\\b|\\.([fFdD]\\b)?)")},{begin:"(".concat(a,")[fFdD]?\\b")},{begin:"\\b(".concat(n,")[fFdD]\\b")},{begin:"\\b0[xX]((".concat(s,")\\.?|(").concat(s,")?\\.(").concat(s,"))[pP][+-]?(").concat(n,")[fFdD]?\\b")},{begin:"\\b(0|[1-9](_*[0-9])*)[lL]?\\b"},{begin:"\\b0[xX](".concat(s,")[lL]?\\b")},{begin:"\\b0(_*[0-7])*[lL]?\\b"},{begin:"\\b0[bB][01](_*[01])*[lL]?\\b"}],relevance:0};function i(e,n,a){return a===-1?"":e.replace(n,(function(s){return i(e,n,a-1)}))}function r(e){var n=e.regex,a="[À-ʸa-zA-Z_$][À-ʸa-zA-Z_$0-9]*",s=a+i("(?:<"+a+"~~~(?:\\s*,\\s*"+a+"~~~)*>)?",/~~~/g,2),r={keyword:["synchronized","abstract","private","var","static","if","const ","for","while","strictfp","finally","protected","import","native","final","void","enum","else","break","transient","catch","instanceof","volatile","case","assert","package","default","public","try","switch","continue","throws","protected","public","private","module","requires","exports","do","sealed","yield","permits"],literal:["false","true","null"],type:["char","boolean","long","float","int","byte","short","double"],built_in:["super","this"]},l={className:"meta",begin:"@"+a,contains:[{begin:/\(/,end:/\)/,contains:["self"]}]},c={className:"params",begin:/\(/,end:/\)/,keywords:r,relevance:0,contains:[e.C_BLOCK_COMMENT_MODE],endsParent:!0};return{name:"Java",aliases:["jsp"],keywords:r,illegal:/<\/|#/,contains:[e.COMMENT("/\\*\\*","\\*/",{relevance:0,contains:[{begin:/\w+@/,relevance:0},{className:"doctag",begin:"@[A-Za-z]+"}]}),{begin:/import java\.[a-z]+\./,keywords:"import",relevance:2},e.C_LINE_COMMENT_MODE,e.C_BLOCK_COMMENT_MODE,{begin:/"""/,end:/"""/,className:"string",contains:[e.BACKSLASH_ESCAPE]},e.APOS_STRING_MODE,e.QUOTE_STRING_MODE,{match:[/\b(?:class|interface|enum|extends|implements|new)/,/\s+/,a],className:{1:"keyword",3:"title.class"}},{match:/non-sealed/,scope:"keyword"},{begin:[n.concat(/(?!else)/,a),/\s+/,a,/\s+/,/=(?!=)/],className:{1:"type",3:"variable",5:"operator"}},{begin:[/record/,/\s+/,a],className:{1:"keyword",3:"title.class"},contains:[c,e.C_LINE_COMMENT_MODE,e.C_BLOCK_COMMENT_MODE]},{beginKeywords:"new throw return else",relevance:0},{begin:["(?:"+s+"\\s+)",e.UNDERSCORE_IDENT_RE,/\s*(?=\()/],className:{2:"title.function"},keywords:r,contains:[{className:"params",begin:/\(/,end:/\)/,keywords:r,relevance:0,contains:[l,e.APOS_STRING_MODE,e.QUOTE_STRING_MODE,t,e.C_BLOCK_COMMENT_MODE]},e.C_LINE_COMMENT_MODE,e.C_BLOCK_COMMENT_MODE]},t,l]}}}}}));
//# sourceMappingURL=p-6ef1ef48.system.js.map