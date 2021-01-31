'use strict';
function log(){
    this.desc = 'desc';
    console.log(this);
}
new log();