import{r as t,c as i,g as s}from"./p-7af91c05.js";const e="@layer ch-grid{ch-grid:has(ch-grid-virtual-scroller)::part(main) {\n    grid-template-rows: -webkit-max-content var(--ch-grid-virtual-scroller-height);grid-template-rows:max-content var(--ch-grid-virtual-scroller-height)}ch-grid-virtual-scroller{display:grid;height:-webkit-max-content;height:-moz-max-content;height:max-content;position:-webkit-sticky;position:sticky;top:0px;grid-auto-rows:-webkit-max-content;grid-auto-rows:max-content;grid-column:1/-1;grid-row:2;grid-template-columns:subgrid}";const h=e;const r=class{constructor(s){t(this,s);this.viewPortItemsChanged=i(this,"viewPortItemsChanged",7);this.hasGridScroll=false;this.hasWindowScroll=false;this.browserHeight=document.documentElement.clientHeight;this.headerHeight=undefined;this.rowsHeight=0;this.rowHeight=0;this.virtualHeight=0;this.maxViewPortItems=7;this.percentScroll=0;this.startIndex=null;this.isScrolling=false;this.items=undefined;this.itemsCount=undefined;this.viewPortItems=undefined}gridEl;gridLayoutEl;resizeObserver;get el(){return s(this)}hasGridScrollHandler(){this.unobserveScroll();this.observeScroll();this.definePercentScroll()}hasWindowScrollHandler(){this.gridLayoutEl.style.overflowX=this.hasWindowScroll?"visible":"auto";this.unobserveScroll();this.observeScroll();this.definePercentScroll()}browserHeightHandler(){this.defineMaxViewPortItems();this.defineVirtualHeight()}headerHeightHandler(){this.el.style.top=`${this.headerHeight}px`}rowsHeightHandler(){this.defineHeaderHeight();this.defineRowHeight()}rowHeightHandler(){this.defineMaxViewPortItems();this.defineVirtualHeight()}virtualHeightHandler(){this.unobserveScroll();this.unobserveResize();this.gridLayoutEl.style.setProperty("--ch-grid-virtual-scroller-height",`${this.virtualHeight}px`);if(Math.ceil(this.percentScroll)!==100){if(this.hasGridScroll){this.gridLayoutEl.scrollTop=this.percentScroll/(100/(this.gridLayoutEl.scrollHeight-this.gridLayoutEl.clientHeight))}else if(this.hasWindowScroll){window.scrollY=this.percentScroll/(100/(this.gridEl.clientHeight-this.browserHeight))}}this.observeScroll();this.observeResize()}maxViewPortItemsHandler(){this.defineViewPortItems()}percentScrollHandler(){this.defineStartIndex()}startIndexHandler(){this.defineViewPortItems()}isScrollingHandler(){if(!this.isScrolling){this.defineMaxViewPortItems();this.defineVirtualHeight()}}itemsHandler(){if(!this.startIndex===null){this.defineStartIndex()}else{this.defineViewPortItems();this.defineVirtualHeight()}}itemsCountHandler(){if(!this.startIndex===null){this.defineStartIndex()}else{this.defineViewPortItems();this.defineVirtualHeight()}}viewPortItemsHandler(){this.viewPortItemsChanged.emit()}viewPortItemsChanged;componentWillLoad(){this.gridLayoutEl=this.el.assignedSlot.parentElement;this.gridEl=this.el.closest("ch-grid");this.resizeObserver=new ResizeObserver(this.resizeHandler);this.observeScroll();this.observeResize()}observeScroll(){let t;if(this.hasGridScroll){t=this.gridLayoutEl}else if(this.hasWindowScroll){t=document}t?.addEventListener("scroll",this.scrollHandler,{passive:true});t?.addEventListener("scrollend",this.scrollEndHandler,{passive:true})}observeResize(){this.resizeObserver.observe(this.el);this.resizeObserver.observe(this.gridEl);this.resizeObserver.observe(document.documentElement);this.resizeObserver.observe(document.body)}unobserveScroll(){document.removeEventListener("scroll",this.scrollHandler);this.gridLayoutEl.removeEventListener("scroll",this.scrollHandler)}unobserveResize(){this.resizeObserver.unobserve(this.el);this.resizeObserver.unobserve(this.gridEl);this.resizeObserver.unobserve(document.documentElement);this.resizeObserver.unobserve(document.body)}scrollHandler=()=>{this.isScrolling=true;this.definePercentScroll()};scrollEndHandler=()=>{this.isScrolling=false};resizeHandler=t=>{t.forEach((t=>{switch(t.target){case this.el:this.rowsHeight=t.contentRect.height;break;case document.documentElement:case document.body:this.browserHeight=document.documentElement.clientHeight;break}}));this.defineHasScroll()};defineHasScroll(){this.hasGridScroll=this.gridLayoutEl.scrollHeight!==this.gridLayoutEl.clientHeight;this.hasWindowScroll=!this.hasGridScroll&&this.gridEl.clientHeight>this.browserHeight}defineHeaderHeight(){this.headerHeight=parseFloat(getComputedStyle(this.gridLayoutEl).gridTemplateRows)}defineRowHeight(){if(this.viewPortItems.length===0){this.rowHeight=0}else if(this.viewPortItems.length>0&&this.percentScroll===0){this.rowHeight=this.rowsHeight/this.viewPortItems.length}else{this.rowHeight=Math.min(this.rowHeight,this.rowsHeight/this.viewPortItems.length)}}defineMaxViewPortItems(){if(this.rowHeight===0){this.maxViewPortItems=7}else{this.maxViewPortItems=Math.ceil(this.browserHeight/this.rowHeight)}}defineVirtualHeight(){if(!this.isScrolling){this.virtualHeight=this.items.length*this.rowHeight}}defineViewPortItems(){this.viewPortItems=this.items.slice(this.startIndex,this.startIndex+this.maxViewPortItems)}defineStartIndex(){const t=this.percentScroll*Math.max(this.items.length-this.maxViewPortItems,0)/100;this.startIndex=this.percentScroll<=50?Math.floor(t):Math.ceil(t)}definePercentScroll(){let t=0;let i=0;if(this.hasGridScroll){t=this.gridLayoutEl.scrollHeight-this.gridLayoutEl.clientHeight;i=this.gridLayoutEl.scrollTop}else if(this.hasWindowScroll){const s=this.gridEl.getBoundingClientRect();t=this.gridEl.clientHeight-this.browserHeight;i=Math.min(s.top>=0?0:s.top*-1,t)}this.percentScroll=t>0?i*100/t:0}static get watchers(){return{hasGridScroll:["hasGridScrollHandler"],hasWindowScroll:["hasWindowScrollHandler"],browserHeight:["browserHeightHandler"],headerHeight:["headerHeightHandler"],rowsHeight:["rowsHeightHandler"],rowHeight:["rowHeightHandler"],virtualHeight:["virtualHeightHandler"],maxViewPortItems:["maxViewPortItemsHandler"],percentScroll:["percentScrollHandler"],startIndex:["startIndexHandler"],isScrolling:["isScrollingHandler"],items:["itemsHandler"],itemsCount:["itemsCountHandler"],viewPortItems:["viewPortItemsHandler"]}}};r.style=h;export{r as ch_grid_virtual_scroller};
//# sourceMappingURL=p-1d617d99.entry.js.map