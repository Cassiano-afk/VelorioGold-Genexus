var __extends=this&&this.__extends||function(){var r=function(e,n){r=Object.setPrototypeOf||{__proto__:[]}instanceof Array&&function(r,e){r.__proto__=e}||function(r,e){for(var n in e)if(Object.prototype.hasOwnProperty.call(e,n))r[n]=e[n]};return r(e,n)};return function(e,n){if(typeof n!=="function"&&n!==null)throw new TypeError("Class extends value "+String(n)+" is not a constructor or null");r(e,n);function t(){this.constructor=e}e.prototype=n===null?Object.create(n):(t.prototype=n.prototype,new t)}}();var __awaiter=this&&this.__awaiter||function(r,e,n,t){function i(r){return r instanceof n?r:new n((function(e){e(r)}))}return new(n||(n=Promise))((function(n,a){function f(r){try{o(t.next(r))}catch(r){a(r)}}function u(r){try{o(t["throw"](r))}catch(r){a(r)}}function o(r){r.done?n(r.value):i(r.value).then(f,u)}o((t=t.apply(r,e||[])).next())}))};var __generator=this&&this.__generator||function(r,e){var n={label:0,sent:function(){if(a[0]&1)throw a[1];return a[1]},trys:[],ops:[]},t,i,a,f;return f={next:u(0),throw:u(1),return:u(2)},typeof Symbol==="function"&&(f[Symbol.iterator]=function(){return this}),f;function u(r){return function(e){return o([r,e])}}function o(u){if(t)throw new TypeError("Generator is already executing.");while(f&&(f=0,u[0]&&(n=0)),n)try{if(t=1,i&&(a=u[0]&2?i["return"]:u[0]?i["throw"]||((a=i["return"])&&a.call(i),0):i.next)&&!(a=a.call(i,u[1])).done)return a;if(i=0,a)u=[u[0]&2,a.value];switch(u[0]){case 0:case 1:a=u;break;case 4:n.label++;return{value:u[1],done:false};case 5:n.label++;i=u[1];u=[0];continue;case 7:u=n.ops.pop();n.trys.pop();continue;default:if(!(a=n.trys,a=a.length>0&&a[a.length-1])&&(u[0]===6||u[0]===2)){n=0;continue}if(u[0]===3&&(!a||u[1]>a[0]&&u[1]<a[3])){n.label=u[1];break}if(u[0]===6&&n.label<a[1]){n.label=a[1];a=u;break}if(a&&n.label<a[2]){n.label=a[2];n.ops.push(u);break}if(a[2])n.ops.pop();n.trys.pop();continue}u=e.call(r,n)}catch(r){u=[6,r];i=0}finally{t=a=0}if(u[0]&5)throw u[1];return{value:u[0]?u[1]:void 0,done:true}}};var __spreadArray=this&&this.__spreadArray||function(r,e,n){if(n||arguments.length===2)for(var t=0,i=e.length,a;t<i;t++){if(a||!(t in e)){if(!a)a=Array.prototype.slice.call(e,0,t);a[t]=e[t]}}return r.concat(a||Array.prototype.slice.call(e))};System.register([],(function(r,e){"use strict";return{execute:function(){var n=this;var t="chameleon";var i={allRenderFn:false,appendChildSlotFix:false,asyncLoading:true,asyncQueue:false,attachStyles:true,cloneNodeFix:false,cmpDidLoad:true,cmpDidRender:true,cmpDidUnload:false,cmpDidUpdate:true,cmpShouldUpdate:true,cmpWillLoad:true,cmpWillRender:true,cmpWillUpdate:true,connectedCallback:true,constructableCSS:true,cssAnnotations:true,devTools:false,disconnectedCallback:true,element:false,event:true,experimentalScopedSlotChanges:false,experimentalSlotFixes:false,formAssociated:true,hasRenderFn:true,hostListener:true,hostListenerTarget:true,hostListenerTargetBody:false,hostListenerTargetDocument:false,hostListenerTargetParent:false,hostListenerTargetWindow:true,hotModuleReplacement:false,hydrateClientSide:false,hydrateServerSide:false,hydratedAttribute:false,hydratedClass:true,initializeNextTick:false,invisiblePrehydration:true,isDebug:false,isDev:false,isTesting:false,lazyLoad:true,lifecycle:true,lifecycleDOMEvents:false,member:true,method:true,mode:false,observeAttribute:true,profile:false,prop:true,propBoolean:true,propMutable:true,propNumber:true,propString:true,reflect:true,scoped:false,scopedSlotTextContentFix:false,scriptDataOpts:false,shadowDelegatesFocus:true,shadowDom:true,slot:true,slotChildNodesFix:false,slotRelocation:true,state:true,style:true,svg:true,taskQueue:true,transformTagName:false,updatable:true,vdomAttribute:true,vdomClass:true,vdomFunctional:false,vdomKey:true,vdomListener:true,vdomPropOrAttr:true,vdomRef:true,vdomRender:true,vdomStyle:true,vdomText:true,vdomXlink:true,watchCallback:true};var a;var f;var u;var o=false;var l=false;var v=false;var s=false;var c=false;var d=r("d",(function(r){var e=new URL(r,qr.t);return e.origin!==Hr.location.origin?e.href:e.pathname}));var p=function(r,e){if(e===void 0){e=""}{return function(){return}}};var h=function(r,e){{return function(){return}}};var y="{visibility:hidden}.hydrated{visibility:inherit}";var m="slot-fb{display:contents}slot-fb[hidden]{display:none}";var b="http://www.w3.org/1999/xlink";var w=["formAssociatedCallback","formResetCallback","formDisabledCallback","formStateRestoreCallback"];var g={};var _="http://www.w3.org/2000/svg";var S="http://www.w3.org/1999/xhtml";var $=function(r){return r!=null};var k=function(r){r=typeof r;return r==="object"||r==="function"};function C(r){var e,n,t;return(t=(n=(e=r.head)===null||e===void 0?void 0:e.querySelector('meta[name="csp-nonce"]'))===null||n===void 0?void 0:n.getAttribute("content"))!==null&&t!==void 0?t:undefined}var A=r("h",(function(r,e){var n=[];for(var t=2;t<arguments.length;t++){n[t-2]=arguments[t]}var i=null;var a=null;var f=null;var u=false;var o=false;var l=[];var v=function(e){for(var n=0;n<e.length;n++){i=e[n];if(Array.isArray(i)){v(i)}else if(i!=null&&typeof i!=="boolean"){if(u=typeof r!=="function"&&!k(i)){i=String(i)}if(u&&o){l[l.length-1].i+=i}else{l.push(u?j(null,i):i)}o=u}}};v(n);if(e){if(e.key){a=e.key}if(e.name){f=e.name}{var s=e.className||e.class;if(s){e.class=typeof s!=="object"?s:Object.keys(s).filter((function(r){return s[r]})).join(" ")}}}var c=j(r,null);c.u=e;if(l.length>0){c.o=l}{c.l=a}{c.v=f}return c}));var j=function(r,e){var n={p:0,h:r,i:e,m:null,o:null};{n.u=null}{n.l=null}{n.v=null}return n};var x=r("H",{});var O=function(r){return r&&r.h===x};var R=function(r,e){if(r!=null&&!k(r)){if(e&4){return r==="false"?false:r===""||!!r}if(e&2){return parseFloat(r)}if(e&1){return String(r)}return r}return r};var T=r("g",(function(r){return Mr(r).$hostElement$}));var L=r("c",(function(r,e,n){var t=T(r);return{emit:function(r){return D(t,e,{bubbles:!!(n&4),composed:!!(n&2),cancelable:!!(n&1),detail:r})}}}));var D=function(r,e,n){var t=qr.ce(e,n);r.dispatchEvent(t);return t};var F=new WeakMap;var M=function(r,e,n){var t=Br.get(r);if(Kr&&n){t=t||new CSSStyleSheet;if(typeof t==="string"){t=e}else{t.replaceSync(e)}}else{t=e}Br.set(r,t)};var U=function(r,e,n){var t;var i=N(e);var a=Br.get(i);r=r.nodeType===11?r:Qr;if(a){if(typeof a==="string"){r=r.head||r;var f=F.get(r);var u=void 0;if(!f){F.set(r,f=new Set)}if(!f.has(i)){{u=Qr.createElement("style");u.innerHTML=a;var o=(t=qr._)!==null&&t!==void 0?t:C(Qr);if(o!=null){u.setAttribute("nonce",o)}r.insertBefore(u,r.querySelector("link"))}if(e.p&4){u.innerHTML+=m}if(f){f.add(i)}}}else if(!r.adoptedStyleSheets.includes(a)){r.adoptedStyleSheets=__spreadArray(__spreadArray([],r.adoptedStyleSheets,true),[a],false)}}return i};var P=function(r){var e=r.S;var n=r.$hostElement$;var t=e.p;var i=p("attachStyles",e.$);var a=U(n.shadowRoot?n.shadowRoot:n.getRootNode(),e);if(t&10){n["s-sc"]=a;n.classList.add(a+"-h")}i()};var N=function(r,e){return"sc-"+r.$};var W=function(r,e,n,t,i,a){if(n!==t){var f=Nr(r,e);var u=e.toLowerCase();if(e==="class"){var o=r.classList;var l=z(n);var v=z(t);o.remove.apply(o,l.filter((function(r){return r&&!v.includes(r)})));o.add.apply(o,v.filter((function(r){return r&&!l.includes(r)})))}else if(e==="style"){{for(var s in n){if(!t||t[s]==null){if(s.includes("-")){r.style.removeProperty(s)}else{r.style[s]=""}}}}for(var s in t){if(!n||t[s]!==n[s]){if(s.includes("-")){r.style.setProperty(s,t[s])}else{r.style[s]=t[s]}}}}else if(e==="key");else if(e==="ref"){if(t){t(r)}}else if(!f&&e[0]==="o"&&e[1]==="n"){if(e[2]==="-"){e=e.slice(3)}else if(Nr(Hr,u)){e=u.slice(2)}else{e=u[2]+e.slice(3)}if(n||t){var c=e.endsWith(B);e=e.replace(H,"");if(n){qr.rel(r,e,n,c)}if(t){qr.ael(r,e,t,c)}}}else{var d=k(t);if((f||d&&t!==null)&&!i){try{if(!r.tagName.includes("-")){var p=t==null?"":t;if(e==="list"){f=false}else if(n==null||r[e]!=p){r[e]=p}}else{r[e]=t}}catch(r){}}var h=false;{if(u!==(u=u.replace(/^xlink\:?/,""))){e=u;h=true}}if(t==null||t===false){if(t!==false||r.getAttribute(e)===""){if(h){r.removeAttributeNS(b,e)}else{r.removeAttribute(e)}}}else if((!f||a&4||i)&&!d){t=t===true?"":t;if(h){r.setAttributeNS(b,e,t)}else{r.setAttribute(e,t)}}}}};var E=/\s/;var z=function(r){return!r?[]:r.split(E)};var B="Capture";var H=new RegExp(B+"$");var Q=function(r,e,n,t){var i=e.m.nodeType===11&&e.m.host?e.m.host:e.m;var a=r&&r.u||g;var f=e.u||g;{for(var u=0,o=q(Object.keys(a));u<o.length;u++){t=o[u];if(!(t in f)){W(i,t,a[t],undefined,n,e.p)}}}for(var l=0,v=q(Object.keys(f));l<v.length;l++){t=v[l];W(i,t,a[t],f[t],n,e.p)}};function q(r){return r.includes("ref")?__spreadArray(__spreadArray([],r.filter((function(r){return r!=="ref"})),true),["ref"],false):r}var G=function(r,e,n,t){var i;var l=e.o[n];var c=0;var d;var p;var h;if(!o){v=true;if(l.h==="slot"){if(a){t.classList.add(a+"-s")}l.p|=l.o?2:1}}if(l.i!==null){d=l.m=Qr.createTextNode(l.i)}else if(l.p&1){d=l.m=Qr.createTextNode("")}else{if(!s){s=l.h==="svg"}d=l.m=Qr.createElementNS(s?_:S,l.p&2?"slot-fb":l.h);if(s&&l.h==="foreignObject"){s=false}{Q(null,l,s)}if($(a)&&d["s-si"]!==a){d.classList.add(d["s-si"]=a)}if(l.o){for(c=0;c<l.o.length;++c){p=G(r,l,c,d);if(p){d.appendChild(p)}}}{if(l.h==="svg"){s=false}else if(d.tagName==="foreignObject"){s=true}}}d["s-hn"]=u;{if(l.p&(2|1)){d["s-sr"]=true;d["s-cr"]=f;d["s-sn"]=l.v||"";d["s-rf"]=(i=l.u)===null||i===void 0?void 0:i.ref;h=r&&r.o&&r.o[n];if(h&&h.h===l.h&&r.m){{I(r.m,false)}}}}return d};var I=function(r,e){qr.p|=1;var n=Array.from(r.childNodes);if(r["s-sr"]&&i.experimentalSlotFixes){var t=r;while(t=t.nextSibling){if(t&&t["s-sn"]===r["s-sn"]&&t["s-sh"]===u){n.push(t)}}}for(var a=n.length-1;a>=0;a--){var f=n[a];if(f["s-hn"]!==u&&f["s-ol"]){Z(f).insertBefore(f,Y(f));f["s-ol"].remove();f["s-ol"]=undefined;f["s-sh"]=undefined;v=true}if(e){I(f,e)}}qr.p&=~1};var K=function(r,e,n,t,i,a){var f=r["s-cr"]&&r["s-cr"].parentNode||r;var o;if(f.shadowRoot&&f.tagName===u){f=f.shadowRoot}for(;i<=a;++i){if(t[i]){o=G(null,n,i,r);if(o){t[i].m=o;f.insertBefore(o,Y(e))}}}};var V=function(r,e,n){for(var t=e;t<=n;++t){var i=r[t];if(i){var a=i.m;ar(i);if(a){{l=true;if(a["s-ol"]){a["s-ol"].remove()}else{I(a,true)}}a.remove()}}}};var X=function(r,e,n,t,i){if(i===void 0){i=false}var a=0;var f=0;var u=0;var o=0;var l=e.length-1;var v=e[0];var s=e[l];var c=t.length-1;var d=t[0];var p=t[c];var h;var y;while(a<=l&&f<=c){if(v==null){v=e[++a]}else if(s==null){s=e[--l]}else if(d==null){d=t[++f]}else if(p==null){p=t[--c]}else if(J(v,d,i)){rr(v,d,i);v=e[++a];d=t[++f]}else if(J(s,p,i)){rr(s,p,i);s=e[--l];p=t[--c]}else if(J(v,p,i)){if(v.h==="slot"||p.h==="slot"){I(v.m.parentNode,false)}rr(v,p,i);r.insertBefore(v.m,s.m.nextSibling);v=e[++a];p=t[--c]}else if(J(s,d,i)){if(v.h==="slot"||p.h==="slot"){I(s.m.parentNode,false)}rr(s,d,i);r.insertBefore(s.m,v.m);s=e[--l];d=t[++f]}else{u=-1;{for(o=a;o<=l;++o){if(e[o]&&e[o].l!==null&&e[o].l===d.l){u=o;break}}}if(u>=0){y=e[u];if(y.h!==d.h){h=G(e&&e[f],n,u,r)}else{rr(y,d,i);e[u]=undefined;h=y.m}d=t[++f]}else{h=G(e&&e[f],n,f,r);d=t[++f]}if(h){{Z(v.m).insertBefore(h,Y(v.m))}}}}if(a>l){K(r,t[c+1]==null?null:t[c+1].m,n,t,f,c)}else if(f>c){V(e,a,l)}};var J=function(r,e,n){if(n===void 0){n=false}if(r.h===e.h){if(r.h==="slot"){return r.v===e.v}if(!n){return r.l===e.l}return true}return false};var Y=function(r){return r&&r["s-ol"]||r};var Z=function(r){return(r["s-ol"]?r["s-ol"]:r).parentNode};var rr=function(r,e,n){if(n===void 0){n=false}var t=e.m=r.m;var i=r.o;var a=e.o;var f=e.h;var u=e.i;var l;if(u===null){{s=f==="svg"?true:f==="foreignObject"?false:s}{if(f==="slot"&&!o);else{Q(r,e,s)}}if(i!==null&&a!==null){X(t,i,e,a,n)}else if(a!==null){if(r.i!==null){t.textContent=""}K(t,null,e,a,0,a.length-1)}else if(i!==null){V(i,0,i.length-1)}if(s&&f==="svg"){s=false}}else if(l=t["s-cr"]){l.parentNode.textContent=u}else if(r.i!==u){t.data=u}};var er=function(r){var e=r.childNodes;for(var n=0,t=e;n<t.length;n++){var i=t[n];if(i.nodeType===1){if(i["s-sr"]){var a=i["s-sn"];i.hidden=false;for(var f=0,u=e;f<u.length;f++){var o=u[f];if(o!==i){if(o["s-hn"]!==i["s-hn"]||a!==""){if(o.nodeType===1&&(a===o.getAttribute("slot")||a===o["s-sn"])){i.hidden=true;break}}else{if(o.nodeType===1||o.nodeType===3&&o.textContent.trim()!==""){i.hidden=true;break}}}}}er(i)}}};var nr=[];var tr=function(r){var e;var n;var t;for(var a=0,f=r.childNodes;a<f.length;a++){var u=f[a];if(u["s-sr"]&&(e=u["s-cr"])&&e.parentNode){n=e.parentNode.childNodes;var o=u["s-sn"];var v=function(){e=n[t];if(!e["s-cn"]&&!e["s-nr"]&&e["s-hn"]!==u["s-hn"]&&!i.experimentalSlotFixes){if(ir(e,o)){var r=nr.find((function(r){return r.k===e}));l=true;e["s-sn"]=e["s-sn"]||o;if(r){r.k["s-sh"]=u["s-hn"];r.C=u}else{e["s-sh"]=u["s-hn"];nr.push({C:u,k:e})}if(e["s-sr"]){nr.map((function(n){if(ir(n.k,e["s-sn"])){r=nr.find((function(r){return r.k===e}));if(r&&!n.C){n.C=r.C}}}))}}else if(!nr.some((function(r){return r.k===e}))){nr.push({k:e})}}};for(t=n.length-1;t>=0;t--){v()}}if(u.nodeType===1){tr(u)}}};var ir=function(r,e){if(r.nodeType===1){if(r.getAttribute("slot")===null&&e===""){return true}if(r.getAttribute("slot")===e){return true}return false}if(r["s-sn"]===e){return true}return e===""};var ar=function(r){{r.u&&r.u.ref&&r.u.ref(null);r.o&&r.o.map(ar)}};var fr=function(r,e,n){if(n===void 0){n=false}var t,i,s,c;var d=r.$hostElement$;var p=r.S;var h=r.A||j(null,null);var y=O(e)?e:A(null,null,e);u=d.tagName;if(p.j){y.u=y.u||{};p.j.map((function(r){var e=r[0],n=r[1];return y.u[n]=d[e]}))}if(n&&y.u){for(var m=0,b=Object.keys(y.u);m<b.length;m++){var w=b[m];if(d.hasAttribute(w)&&!["key","ref","style","class"].includes(w)){y.u[w]=d[w]}}}y.h=null;y.p|=4;r.A=y;y.m=h.m=d.shadowRoot||d;{a=d["s-sc"]}o=(p.p&1)!==0;{f=d["s-cr"];l=false}rr(h,y,n);{qr.p|=1;if(v){tr(y.m);for(var g=0,_=nr;g<_.length;g++){var S=_[g];var $=S.k;if(!$["s-ol"]){var k=Qr.createTextNode("");k["s-nr"]=$;$.parentNode.insertBefore($["s-ol"]=k,$)}}for(var C=0,x=nr;C<x.length;C++){var S=x[C];var $=S.k;var R=S.C;if(R){var T=R.parentNode;var L=R.nextSibling;{var k=(t=$["s-ol"])===null||t===void 0?void 0:t.previousSibling;while(k){var D=(i=k["s-nr"])!==null&&i!==void 0?i:null;if(D&&D["s-sn"]===$["s-sn"]&&T===D.parentNode){D=D.nextSibling;while(D===$||(D===null||D===void 0?void 0:D["s-sr"])){D=D===null||D===void 0?void 0:D.nextSibling}if(!D||!D["s-nr"]){L=D;break}}k=k.previousSibling}}if(!L&&T!==$.parentNode||$.nextSibling!==L){if($!==L){if(!$["s-hn"]&&$["s-ol"]){$["s-hn"]=$["s-ol"].parentNode.nodeName}T.insertBefore($,L);if($.nodeType===1){$.hidden=(s=$["s-ih"])!==null&&s!==void 0?s:false}}}$&&typeof R["s-rf"]==="function"&&R["s-rf"]($)}else{if($.nodeType===1){if(n){$["s-ih"]=(c=$.hidden)!==null&&c!==void 0?c:false}$.hidden=true}}}}if(l){er(y.m)}qr.p&=~1;nr.length=0}f=undefined};var ur=function(r,e){if(e&&!r.O&&e["s-p"]){e["s-p"].push(new Promise((function(e){return r.O=e})))}};var or=function(r,e){{r.p|=16}if(r.p&4){r.p|=512;return}ur(r,r.R);var n=function(){return lr(r,e)};return ne(n)};var lr=function(r,e){var n=p("scheduleUpdate",r.S.$);var t=r.T;var i;if(e){{r.p|=256;if(r.L){r.L.map((function(r){var e=r[0],n=r[1];return mr(t,e,n)}));r.L=undefined}}{i=mr(t,"componentWillLoad")}}else{{i=mr(t,"componentWillUpdate")}}{i=vr(i,(function(){return mr(t,"componentWillRender")}))}n();return vr(i,(function(){return cr(r,t,e)}))};var vr=function(r,e){return sr(r)?r.then(e):e()};var sr=function(r){return r instanceof Promise||r&&r.then&&typeof r.then==="function"};var cr=function(r,e,t){return __awaiter(n,void 0,void 0,(function(){var n,i,a,f,u,o,l;return __generator(this,(function(v){i=r.$hostElement$;a=p("update",r.S.$);f=i["s-rc"];if(t){P(r)}u=p("render",r.S.$);{dr(r,e,i,t)}if(f){f.map((function(r){return r()}));i["s-rc"]=undefined}u();a();{o=(n=i["s-p"])!==null&&n!==void 0?n:[];l=function(){return pr(r)};if(o.length===0){l()}else{Promise.all(o).then(l);r.p|=4;o.length=0}}return[2]}))}))};var dr=function(r,e,n,t){try{e=e.render&&e.render();{r.p&=~16}{r.p|=2}{{{fr(r,e,t)}}}}catch(e){Wr(e,r.$hostElement$)}return null};var pr=function(r){var e=r.S.$;var n=r.$hostElement$;var t=p("postUpdate",e);var i=r.T;var a=r.R;{mr(i,"componentDidRender")}if(!(r.p&64)){r.p|=64;{br(n)}{mr(i,"componentDidLoad")}t();{r.D(n);if(!a){yr()}}}else{{mr(i,"componentDidUpdate")}t()}{r.F(n)}{if(r.O){r.O();r.O=undefined}if(r.p&512){re((function(){return or(r,false)}))}r.p&=~(4|512)}};var hr=r("f",(function(r){{var e=Mr(r);var n=e.$hostElement$.isConnected;if(n&&(e.p&(2|16))===2){or(e,false)}return n}}));var yr=function(r){{br(Qr.documentElement)}re((function(){return D(Hr,"appload",{detail:{namespace:t}})}))};var mr=function(r,e,n){if(r&&r[e]){try{return r[e](n)}catch(r){Wr(r)}}return undefined};var br=function(r){return r.classList.add("hydrated")};var wr=function(r,e){return Mr(r).M.get(e)};var gr=function(r,e,n,t){var i=Mr(r);var a=i.$hostElement$;var f=i.M.get(e);var u=i.p;var o=i.T;n=R(n,t.U[e][0]);var l=Number.isNaN(f)&&Number.isNaN(n);var v=n!==f&&!l;if((!(u&8)||f===undefined)&&v){i.M.set(e,n);if(o){if(t.P&&u&128){var s=t.P[e];if(s){s.map((function(r){try{o[r](n,f,e)}catch(r){Wr(r,a)}}))}}if((u&(2|16))===2){if(o.componentShouldUpdate){if(o.componentShouldUpdate(n,f,e)===false){return}}or(i,false)}}}};var _r=function(r,e,n){var t;var i=r.prototype;if(e.p&64&&n&1){w.forEach((function(r){return Object.defineProperty(i,r,{value:function(){var e=[];for(var n=0;n<arguments.length;n++){e[n]=arguments[n]}var t=Mr(this);var i=t.T;if(!i){t.N.then((function(n){var t=n[r];typeof t==="function"&&t.call.apply(t,__spreadArray([n],e,false))}))}else{var a=i[r];typeof a==="function"&&a.call.apply(a,__spreadArray([i],e,false))}}})}))}if(e.U){if(r.watchers){e.P=r.watchers}var a=Object.entries(e.U);a.map((function(r){var t=r[0],a=r[1][0];if(a&31||n&2&&a&32){Object.defineProperty(i,t,{get:function(){return wr(this,t)},set:function(r){gr(this,t,r,e)},configurable:true,enumerable:true})}else if(n&1&&a&64){Object.defineProperty(i,t,{value:function(){var r=[];for(var e=0;e<arguments.length;e++){r[e]=arguments[e]}var n;var i=Mr(this);return(n=i===null||i===void 0?void 0:i.W)===null||n===void 0?void 0:n.then((function(){var e;return(e=i.T)===null||e===void 0?void 0:e[t].apply(e,r)}))}})}}));if(n&1){var f=new Map;i.attributeChangedCallback=function(r,n,t){var a=this;qr.jmp((function(){var u;var o=f.get(r);if(a.hasOwnProperty(o)){t=a[o];delete a[o]}else if(i.hasOwnProperty(o)&&typeof a[o]==="number"&&a[o]==t){return}else if(o==null){var l=Mr(a);var v=l===null||l===void 0?void 0:l.p;if(v&&!(v&8)&&v&128&&t!==n){var s=l.T;var c=(u=e.P)===null||u===void 0?void 0:u[r];c===null||c===void 0?void 0:c.forEach((function(e){if(s[e]!=null){s[e].call(s,t,n,r)}}))}return}a[o]=t===null&&typeof a[o]==="boolean"?false:t}))};r.observedAttributes=Array.from(new Set(__spreadArray(__spreadArray([],Object.keys((t=e.P)!==null&&t!==void 0?t:{}),true),a.filter((function(r){var e=r[0],n=r[1];return n[0]&15})).map((function(r){var n=r[0],t=r[1];var i;var a=t[1]||n;f.set(a,n);if(t[0]&512){(i=e.j)===null||i===void 0?void 0:i.push([n,a])}return a})),true)))}}return r};var Sr=function(r,e,t,i){return __awaiter(n,void 0,void 0,(function(){var n,i,a,f,u,o,l,v,s;return __generator(this,(function(c){switch(c.label){case 0:if(!((e.p&32)===0))return[3,5];e.p|=32;i=t.B;if(!i)return[3,3];n=zr(t);if(!n.then)return[3,2];a=h();return[4,n];case 1:n=c.sent();a();c.label=2;case 2:if(!n.isProxied){{t.P=n.watchers}_r(n,t,2);n.isProxied=true}f=p("createInstance",t.$);{e.p|=8}try{new n(e)}catch(r){Wr(r)}{e.p&=~8}{e.p|=128}f();$r(e.T);return[3,4];case 3:n=r.constructor;customElements.whenDefined(t.$).then((function(){return e.p|=128}));c.label=4;case 4:if(n.style){u=n.style;o=N(t);if(!Br.has(o)){l=p("registerStyles",t.$);M(o,u,!!(t.p&1));l()}}c.label=5;case 5:v=e.R;s=function(){return or(e,true)};if(v&&v["s-rc"]){v["s-rc"].push(s)}else{s()}return[2]}}))}))};var $r=function(r){{mr(r,"connectedCallback")}};var kr=function(r){if((qr.p&1)===0){var e=Mr(r);var n=e.S;var t=p("connectedCallback",n.$);if(!(e.p&1)){e.p|=1;{if(n.p&(4|8)){Cr(r)}}{var i=r;while(i=i.parentNode||i.host){if(i["s-p"]){ur(e,e.R=i);break}}}if(n.U){Object.entries(n.U).map((function(e){var n=e[0],t=e[1][0];if(t&31&&r.hasOwnProperty(n)){var i=r[n];delete r[n];r[n]=i}}))}{Sr(r,e,n)}}else{Or(r,e,n.H);if(e===null||e===void 0?void 0:e.T){$r(e.T)}else if(e===null||e===void 0?void 0:e.N){e.N.then((function(){return $r(e.T)}))}}t()}};var Cr=function(r){var e=r["s-cr"]=Qr.createComment("");e["s-cn"]=true;r.insertBefore(e,r.firstChild)};var Ar=function(r){{mr(r,"disconnectedCallback")}};var jr=function(r){return __awaiter(n,void 0,void 0,(function(){var e;return __generator(this,(function(n){if((qr.p&1)===0){e=Mr(r);{if(e.q){e.q.map((function(r){return r()}));e.q=undefined}}if(e===null||e===void 0?void 0:e.T){Ar(e.T)}else if(e===null||e===void 0?void 0:e.N){e.N.then((function(){return Ar(e.T)}))}}return[2]}))}))};var xr=r("b",(function(r,e){if(e===void 0){e={}}var n;var t=p();var i=[];var a=e.exclude||[];var f=Hr.customElements;var u=Qr.head;var o=u.querySelector("meta[charset]");var l=Qr.createElement("style");var v=[];var s;var c=true;Object.assign(qr,e);qr.t=new URL(e.resourcesUrl||"./",Qr.baseURI).href;var d=false;r.map((function(r){r[1].map((function(e){var n;var t={p:e[0],$:e[1],U:e[2],H:e[3]};if(t.p&4){d=true}{t.U=e[2]}{t.H=e[3]}{t.j=[]}{t.P=(n=e[4])!==null&&n!==void 0?n:{}}var u=t.$;var o=function(r){__extends(e,r);function e(e){var n=r.call(this,e)||this;e=n;Pr(e,t);if(t.p&1){{{e.attachShadow({mode:"open",delegatesFocus:!!(t.p&16)})}}}return n}e.prototype.connectedCallback=function(){var r=this;if(s){clearTimeout(s);s=null}if(c){v.push(this)}else{qr.jmp((function(){return kr(r)}))}};e.prototype.disconnectedCallback=function(){var r=this;qr.jmp((function(){return jr(r)}))};e.prototype.componentOnReady=function(){return Mr(this).N};return e}(HTMLElement);if(t.p&64){o.formAssociated=true}t.B=r[0];if(!a.includes(u)&&!f.get(u)){i.push(u);f.define(u,_r(o,t,1))}}))}));if(i.length>0){if(d){l.textContent+=m}{l.textContent+=i+y}if(l.innerHTML.length){l.setAttribute("data-styles","");var h=(n=qr._)!==null&&n!==void 0?n:C(Qr);if(h!=null){l.setAttribute("nonce",h)}u.insertBefore(l,o?o.nextSibling:u.firstChild)}}c=false;if(v.length){v.map((function(r){return r.connectedCallback()}))}else{{qr.jmp((function(){return s=setTimeout(yr,30)}))}}t()}));var Or=function(r,e,n,t){if(n){n.map((function(n){var t=n[0],i=n[1],a=n[2];var f=Tr(r,t);var u=Rr(e,a);var o=Lr(t);qr.ael(f,i,u,o);(e.q=e.q||[]).push((function(){return qr.rel(f,i,u,o)}))}))}};var Rr=function(r,e){return function(n){try{{if(r.p&256){r.T[e](n)}else{(r.L=r.L||[]).push([e,n])}}}catch(r){Wr(r)}}};var Tr=function(r,e){if(e&8)return Hr;return r};var Lr=function(r){return Gr?{passive:(r&1)!==0,capture:(r&2)!==0}:(r&2)!==0};var Dr=r("s",(function(r){return qr._=r}));var Fr=new WeakMap;var Mr=function(r){return Fr.get(r)};var Ur=r("r",(function(r,e){return Fr.set(e.T=r,e)}));var Pr=function(r,e){var n={p:0,$hostElement$:r,S:e,M:new Map};{n.W=new Promise((function(r){return n.F=r}))}{n.N=new Promise((function(r){return n.D=r}));r["s-p"]=[];r["s-rc"]=[]}Or(r,n,e.H);return Fr.set(r,n)};var Nr=function(r,e){return e in r};var Wr=function(r,e){return(0,console.error)(r,e)};var Er=new Map;var zr=function(r,n,t){var i=r.$.replace(/-/g,"_");var a=r.B;var f=Er.get(a);if(f){return f[i]}
/*!__STENCIL_STATIC_IMPORT_SWITCH__*/return e.import("./".concat(a,".entry.js").concat("")).then((function(r){{Er.set(a,r)}return r[i]}),Wr)};var Br=new Map;var Hr=typeof window!=="undefined"?window:{};var Qr=Hr.document||{head:{}};var qr={p:0,t:"",jmp:function(r){return r()},raf:function(r){return requestAnimationFrame(r)},ael:function(r,e,n,t){return r.addEventListener(e,n,t)},rel:function(r,e,n,t){return r.removeEventListener(e,n,t)},ce:function(r,e){return new CustomEvent(r,e)}};var Gr=function(){var r=false;try{Qr.addEventListener("e",null,Object.defineProperty({},"passive",{get:function(){r=true}}))}catch(r){}return r}();var Ir=r("p",(function(r){return Promise.resolve(r)}));var Kr=function(){try{new CSSStyleSheet;return typeof(new CSSStyleSheet).replaceSync==="function"}catch(r){}return false}();var Vr=[];var Xr=[];var Jr=function(r,e){return function(n){r.push(n);if(!c){c=true;if(e&&qr.p&4){re(Zr)}else{qr.raf(Zr)}}}};var Yr=function(r){for(var e=0;e<r.length;e++){try{r[e](performance.now())}catch(r){Wr(r)}}r.length=0};var Zr=function(){Yr(Vr);{Yr(Xr);if(c=Vr.length>0){qr.raf(Zr)}}};var re=function(r){return Ir().then(r)};var ee=r("a",Jr(Vr,false));var ne=r("w",Jr(Xr,true))}}}));
//# sourceMappingURL=p-62fc4e49.system.js.map