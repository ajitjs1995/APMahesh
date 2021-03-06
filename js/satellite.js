_satellite._scrollTracker = {  
    callback: function() {  
        try {  
            var _sT = _satellite._scrollTracker,  
                h = document.documentElement,  
                b = document.body,  
                st = 'scrollTop',  
                sh = 'scrollHeight',  
                p = 0,  
                pv = false;  
            this.percent = this.percent || {};  
            p = Math.round((h[st] || b[st]) / ((h[sh] || b[sh]) - h.clientHeight) * 100);  
            pv = (p >= 25) && !this.percent[25] && 25 || pv;  
            pv = (p >= 50) && !this.percent[50] && 50 || pv;  
            pv = (p >= 75) && !this.percent[75] && 75 || pv;  
            pv = (p >= 100) && !this.percent[100] && 100 || pv;  
            if (pv) {  
                this.percent[pv] = true;  
                _sT.percent = pv;  
                _satellite.track('pagescroll_percent_hit');  
            }  
            if (this.percent[25] && this.percent[50] && this.percent[75] && this.percent[100]) {  
                window.clearInterval(_satellite._scrollTracker.interval);  
            }  
        } catch (e) {}  
    }  
};  
try {  
    _satellite._scrollTracker.interval = window.setInterval(_satellite._scrollTracker.callback, 250);  
} catch (e) {}  
