const n=n=>navigator.userAgent.includes("Mac")?n.metaKey:n.ctrlKey;function t(n,t){return(n.buttons&t)===t}var a;(function(n){n[n["KEY_SHORTCUT"]=-1]="KEY_SHORTCUT";n[n["LEFT"]=0]="LEFT";n[n["WHEEL"]=1]="WHEEL";n[n["RIGHT"]=2]="RIGHT";n[n["BACK"]=3]="BACK";n[n["FORWARD"]=4]="FORWARD"})(a||(a={}));var o;(function(n){n[n["LEFT"]=1]="LEFT";n[n["RIGHT"]=2]="RIGHT";n[n["WHEEL"]=4]="WHEEL";n[n["BACK"]=8]="BACK";n[n["FORWARD"]=16]="FORWARD"})(o||(o={}));function c(){const n=[];let t=document;while(t&&t.activeElement){n.push(t.activeElement);t=t.activeElement.shadowRoot}return n.reverse()}export{a as M,t as a,o as b,c as f,n as m};
//# sourceMappingURL=p-b3df8b9e.js.map