/*
This software is allowed to use under GPL or you need to obtain Commercial or Enterise License
to use it in not GPL project. Please contact sales@dhtmlx.com for details
*/
scheduler.form_blocks.recurring = {
    render: function () {
        return scheduler.__recurring_template
    },
    _ds: {},
    _init_set_value: function (a, b, c) {
        function d(a) {
            for (var b = 0; b < a.length; b++) {
                var c = a[b];
                c.type == "checkbox" || c.type == "radio" ? (g[c.name] || (g[c.name] = []), g[c.name].push(c)) : g[c.name] = c
            }
        }
        function f(a) {
            for (var b = g[a], c = 0; c < b.length; c++) if (b[c].checked) return b[c].value
        }
        function e() {
            m("dhx_repeat_day").style.display = "none";
            m("dhx_repeat_week").style.display = "none";
            m("dhx_repeat_month").style.display = "none";
            m("dhx_repeat_year").style.display =
                "none";
            m("dhx_repeat_" + this.value).style.display = "block"
        }
        function h(a) {
            var b = [f("repeat")];
            for (p[b[0]](b, a); b.length < 5; ) b.push("");
            var c = "";
            if (g.end[0].checked) a.end = new Date(9999, 1, 1), c = "no";
            else if (g.end[2].checked) a.end = i(g.date_of_end.value);
            else {
                scheduler.transpose_type(b.join("_"));
                var c = Math.max(1, g.occurences_count.value),
                    e = b[0] == "week" && b[4] && b[4].toString().indexOf(scheduler.config.start_on_monday ? 1 : 0) == -1 ? 1 : 0;
                a.end = scheduler.date.add(new Date(a.start), c + e, b.join("_"))
            }
            return b.join("_") +
                "#" + c
        }
        function j(a, b) {
            var c = a.split("#"),
                a = c[0].split("_");
            q[a[0]](a, b);
            var e = g.repeat[{
                day: 0,
                week: 1,
                month: 2,
                year: 3
            }[a[0]]];
            switch (c[1]) {
                case "no":
                    g.end[0].checked = !0;
                    break;
                case "":
                    g.end[2].checked = !0;
                    g.date_of_end.value = k(b.end);
                    break;
                default:
                    g.end[1].checked = !0, g.occurences_count.value = c[1]
            }
            e.checked = !0;
            e.onclick()
        }
        scheduler.form_blocks.recurring._ds = {
            start: c.start_date,
            end: c._end_date
        };
        var i = scheduler.date.str_to_date(scheduler.config.repeat_date),
            k = scheduler.date.date_to_str(scheduler.config.repeat_date),
            l = a.getElementsByTagName("FORM")[0],
            g = [];
        d(l.getElementsByTagName("INPUT"));
        d(l.getElementsByTagName("SELECT"));
        var m = function (a) {
            return document.getElementById(a)
        };
        scheduler.form_blocks.recurring._get_repeat_code = h;
        var p = {
            month: function (a, b) {
                f("month_type") == "d" ? (a.push(Math.max(1, g.month_count.value)), b.start.setDate(g.month_day.value)) : (a.push(Math.max(1, g.month_count2.value)), a.push(g.month_day2.value), a.push(Math.max(1, g.month_week2.value)), b.start.setDate(1));
                b._start = !0
            },
            week: function (a, b) {
                a.push(Math.max(1,
                g.week_count.value));
                a.push("");
                a.push("");
                for (var c = [], e = g.week_day, d = 0; d < e.length; d++) e[d].checked && c.push(e[d].value);
                c.length || c.push(b.start.getDay());
                b.start = scheduler.date.week_start(b.start);
                b._start = !0;
                a.push(c.sort().join(","))
            },
            day: function (a) {
                f("day_type") == "d" ? a.push(Math.max(1, g.day_count.value)) : (a.push("week"), a.push(1), a.push(""), a.push(""), a.push("1,2,3,4,5"), a.splice(0, 1))
            },
            year: function (a, b) {
                f("year_type") == "d" ? (a.push("1"), b.start.setMonth(0), b.start.setDate(g.year_day.value),
                b.start.setMonth(g.year_month.value)) : (a.push("1"), a.push(g.year_day2.value), a.push(g.year_week2.value), b.start.setDate(1), b.start.setMonth(g.year_month2.value));
                b._start = !0
            }
        }, q = {
            week: function (a) {
                g.week_count.value = a[1];
                for (var b = g.week_day, c = a[4].split(","), e = {}, d = 0; d < c.length; d++) e[c[d]] = !0;
                for (d = 0; d < b.length; d++) b[d].checked = !!e[b[d].value]
            },
            month: function (a, b) {
                a[2] == "" ? (g.month_type[0].checked = !0, g.month_count.value = a[1], g.month_day.value = b.start.getDate()) : (g.month_type[1].checked = !0, g.month_count2.value = a[1], g.month_week2.value = a[3], g.month_day2.value = a[2])
            },
            day: function (a) {
                g.day_type[0].checked = !0;
                g.day_count.value = a[1]
            },
            year: function (a, b) {
                a[2] == "" ? (g.year_type[0].checked = !0, g.year_day.value = b.start.getDate(), g.year_month.value = b.start.getMonth()) : (g.year_type[1].checked = !0, g.year_week2.value = a[3], g.year_day2.value = a[2], g.year_month2.value = b.start.getMonth())
            }
        };
        scheduler.form_blocks.recurring._set_repeat_code = j;
        for (var n = 0; n < l.elements.length; n++) {
            var o = l.elements[n];
            switch (o.name) {
                case "repeat":
                    o.onclick = e
            }
        }
        scheduler._lightbox._rec_init_done = !0
    },
    set_value: function (a, b, c) {
        var d = scheduler.form_blocks.recurring;
        scheduler._lightbox._rec_init_done || d._init_set_value(a, b, c);
        a.open = !c.rec_type;
        a.blocked = c.event_pid && c.event_pid != "0" ? !0 : !1;
        var f = d._ds;
        f.start = c.start_date;
        f.end = c._end_date;
        d.button_click(0, a.previousSibling.firstChild.firstChild, a, a);
        b && d._set_repeat_code(b, f)
    },
    get_value: function (a, b) {
        if (a.open) {
            var c = scheduler.form_blocks.recurring._ds;
            b.rec_type = scheduler.form_blocks.recurring._get_repeat_code(c);
            c._start ? (b.start_date = new Date(c.start), b._start_date = new Date(c.start), c._start = !1) : b._start_date = null;
            b._end_date = b.end_date = c.end;
            b.rec_pattern = b.rec_type.split("#")[0]
        } else b.rec_type = b.rec_pattern = "", b._end_date = b.end_date;
        return b.rec_type
    },
    focus: function () { },
    button_click: function (a, b, c, d) {
        !d.open && !d.blocked ? (d.style.height = "115px", b.style.backgroundPosition = "-5px 0px", b.nextSibling.innerHTML = scheduler.locale.labels.button_recurring_open) : (d.style.height = "0px", b.style.backgroundPosition = "-5px 20px",
        b.nextSibling.innerHTML = scheduler.locale.labels.button_recurring);
        d.open = !d.open;
        scheduler.setLightboxSize()
    }
};
scheduler._rec_markers = {};
scheduler._rec_markers_pull = {};
scheduler._add_rec_marker = function (a, b) {
    a._pid_time = b;
    this._rec_markers[a.id] = a;
    this._rec_markers_pull[a.event_pid] || (this._rec_markers_pull[a.event_pid] = {});
    this._rec_markers_pull[a.event_pid][b] = a
};
scheduler._get_rec_marker = function (a, b) {
    var c = this._rec_markers_pull[b];
    return c ? c[a] : null
};
scheduler._get_rec_markers = function (a) {
    return this._rec_markers_pull[a] || []
};
scheduler._rec_temp = [];
scheduler.attachEvent("onEventLoading", function (a) {
    a.event_pid != 0 && scheduler._add_rec_marker(a, a.event_length * 1E3);
    if (a.rec_type) a.rec_pattern = a.rec_type.split("#")[0];
    return !0
});
scheduler.attachEvent("onEventIdChange", function (a, b) {
    if (!this._ignore_call) {
        this._ignore_call = !0;
        for (var c = 0; c < this._rec_temp.length; c++) {
            var d = this._rec_temp[c];
            if (d.event_pid == a) d.event_pid = b, this.changeEventId(d.id, b + "#" + d.id.split("#")[1])
        }
        delete this._ignore_call
    }
});
scheduler.attachEvent("onBeforeEventDelete", function (a) {
    var b = this.getEvent(a);
    if (a.toString().indexOf("#") != -1 || b.event_pid && b.event_pid != "0" && b.rec_type != "none") {
        var a = a.split("#"),
            c = this.uid(),
            d = a[1] ? a[1] : b._pid_time / 1E3,
            f = this._copy_event(b);
        f.id = c;
        f.event_pid = b.event_pid || a[0];
        f.event_length = d;
        f.rec_type = f.rec_pattern = "none";
        this.addEvent(f);
        this._add_rec_marker(f, d * 1E3)
    } else {
        b.rec_type && this._roll_back_dates(b);
        var e = this._get_rec_markers(a),
            h;
        for (h in e) if (e.hasOwnProperty(h)) a = e[h].id, this.getEvent(a) && this.deleteEvent(a, !0)
    }
    return !0
});
scheduler.attachEvent("onEventChanged", function (a) {
    if (this._loading) return !0;
    var b = this.getEvent(a);
    if (a.toString().indexOf("#") != -1) {
        var a = a.split("#"),
            c = this.uid();
        this._not_render = !0;
        var d = this._copy_event(b);
        d.id = c;
        d.event_pid = a[0];
        d.event_length = a[1];
        d.rec_type = d.rec_pattern = "";
        this.addEvent(d);
        this._not_render = !1;
        this._add_rec_marker(d, a[1] * 1E3)
    } else {
        b.rec_type && this._roll_back_dates(b);
        var f = this._get_rec_markers(a),
            e;
        for (e in f) f.hasOwnProperty(e) && (delete this._rec_markers[f[e].id], this.deleteEvent(f[e].id, !0));
        delete this._rec_markers_pull[a];
        for (var h = !1, j = 0; j < this._rendered.length; j++) this._rendered[j].getAttribute("event_id") == a && (h = !0);
        if (!h) this._select_id = null
    }
    return !0
});
scheduler.attachEvent("onEventAdded", function (a) {
    if (!this._loading) {
        var b = this.getEvent(a);
        b.rec_type && !b.event_length && this._roll_back_dates(b)
    }
    return !0
});
scheduler.attachEvent("onEventSave", function (a, b) {
    var c = this.getEvent(a);
    var t = this._copy_event(b);

    if (t.text == '') {
        alert("Description should not be blank")
        return false
    }
    else {
        return !0

    }

    if (!c.rec_type && b.rec_type && (a + "").indexOf("#") == -1)
        this._select_id = null;

    return !0






});
scheduler.attachEvent("onEventCreated", function (a) {
    var b = this.getEvent(a);
    if (!b.rec_type) b.rec_type = b.rec_pattern = b.event_length = b.event_pid = "";
    return !0
});
scheduler.attachEvent("onEventCancel", function (a) {
    var b = this.getEvent(a);
    b.rec_type && (this._roll_back_dates(b), this.render_view_data())
});
scheduler._roll_back_dates = function (a) {
    a.event_length = (a.end_date.valueOf() - a.start_date.valueOf()) / 1E3;
    a.end_date = a._end_date;
    a._start_date && (a.start_date.setMonth(0), a.start_date.setDate(a._start_date.getDate()), a.start_date.setMonth(a._start_date.getMonth()), a.start_date.setFullYear(a._start_date.getFullYear()))
};
scheduler.validId = function (a) {
    return a.toString().indexOf("#") == -1
};
scheduler.showLightbox_rec = scheduler.showLightbox;
scheduler.showLightbox = function (a) {
    var b = this.getEvent(a).event_pid;
    a.toString().indexOf("#") != -1 && (b = a.split("#")[0]);
    if (!b || b == 0 || !this.locale.labels.confirm_recurring || !confirm(this.locale.labels.confirm_recurring)) return this.showLightbox_rec(a);
    b = this.getEvent(b);
    b._end_date = b.end_date;
    b.end_date = new Date(b.start_date.valueOf() + b.event_length * 1E3);
    return this.showLightbox_rec(b.id)
};
scheduler.get_visible_events_rec = scheduler.get_visible_events;
scheduler.get_visible_events = function () {
    for (var a = 0; a < this._rec_temp.length; a++) delete this._events[this._rec_temp[a].id];
    this._rec_temp = [];
    for (var b = this.get_visible_events_rec(), c = [], a = 0; a < b.length; a++) b[a].rec_type ? b[a].rec_pattern != "none" && this.repeat_date(b[a], c) : c.push(b[a]);
    return c
};
(function () {
    var a = scheduler.is_one_day_event;
    scheduler.is_one_day_event = function (b) {
        return b.rec_type ? !0 : a.call(this, b)
    }
})();
scheduler.transponse_size = {
    day: 1,
    week: 7,
    month: 1,
    year: 12
};
scheduler.date.day_week = function (a, b, c) {
    a.setDate(1);
    var c = (c - 1) * 7,
        d = a.getDay(),
        f = b * 1 + c - d + 1;
    a.setDate(f <= c ? f + 7 : f)
};
scheduler.transpose_day_week = function (a, b, c, d, f) {
    for (var e = (a.getDay() || (scheduler.config.start_on_monday ? 7 : 0)) - c, h = 0; h < b.length; h++) if (b[h] > e) return a.setDate(a.getDate() + b[h] * 1 - e - (d ? c : f));
    this.transpose_day_week(a, b, c + d, null, c)
};
scheduler.transpose_type = function (a) {
    var b = "transpose_" + a;
    if (!this.date[b]) {
        var c = a.split("_"),
            d = 864E5,
            f = "add_" + a,
            e = this.transponse_size[c[0]] * c[1];
        if (c[0] == "day" || c[0] == "week") {
            var h = null;
            if (c[4] && (h = c[4].split(","), scheduler.config.start_on_monday)) {
                for (var j = 0; j < h.length; j++) h[j] = h[j] * 1 || 7;
                h.sort()
            }
            this.date[b] = function (a, b) {
                var c = Math.floor((b.valueOf() - a.valueOf()) / (d * e));
                c > 0 && a.setDate(a.getDate() + c * e);
                h && scheduler.transpose_day_week(a, h, 1, e)
            };
            this.date[f] = function (a, b) {
                var c = new Date(a.valueOf());
                if (h) for (var d = 0; d < b; d++) scheduler.transpose_day_week(c, h, 0, e);
                else c.setDate(c.getDate() + b * e);
                return c
            }
        } else if (c[0] == "month" || c[0] == "year") this.date[b] = function (a, b) {
            var d = Math.ceil((b.getFullYear() * 12 + b.getMonth() * 1 - (a.getFullYear() * 12 + a.getMonth() * 1)) / e);
            d >= 0 && a.setMonth(a.getMonth() + d * e);
            c[3] && scheduler.date.day_week(a, c[2], c[3])
        }, this.date[f] = function (a, b) {
            var d = new Date(a.valueOf());
            d.setMonth(d.getMonth() + b * e);
            c[3] && scheduler.date.day_week(d, c[2], c[3]);
            return d
        }
    }
};
scheduler.repeat_date = function (a, b, c, d, f) {
    var d = d || this._min_date,
        f = f || this._max_date,
        e = new Date(a.start_date.valueOf());
    if (!a.rec_pattern && a.rec_type) a.rec_pattern = a.rec_type.split("#")[0];
    this.transpose_type(a.rec_pattern);
    for (scheduler.date["transpose_" + a.rec_pattern](e, d); e < a.start_date || e.valueOf() + a.event_length * 1E3 <= d.valueOf(); ) e = this.date.add(e, 1, a.rec_pattern);
    for (; e < f && e < a.end_date; ) {
        var h = this._get_rec_marker(e.valueOf(), a.id);
        if (h) c && b.push(h);
        else {
            var j = new Date(e.valueOf() + a.event_length * 1E3),
                i = this._copy_event(a);
            i.text = a.text;
            i.start_date = e;
            i.event_pid = a.id;
            i.id = a.id + "#" + Math.ceil(e.valueOf() / 1E3);
            i.end_date = j;
            var k = i.start_date.getTimezoneOffset() - i.end_date.getTimezoneOffset();
            if (k) i.end_date = k > 0 ? new Date(e.valueOf() + a.event_length * 1E3 - k * 6E4) : new Date(i.end_date.valueOf() + k * 6E4);
            i._timed = this.is_one_day_event(i);
            if (!i._timed && !this._table_view && !this.config.multi_day) break;
            b.push(i);
            c || (this._events[i.id] = i, this._rec_temp.push(i))
        }
        e = this.date.add(e, 1, a.rec_pattern)
    }
};
scheduler.getRecDates = function (a, b) {
    var c = typeof a == "object" ? a : scheduler.getEvent(a),
        d = 0,
        f = [],
        b = b || 1E3,
        e = new Date(c.start_date.valueOf()),
        h = new Date(e.valueOf());
    if (!c.rec_type) return [{
        start_date: c.start_date,
        end_date: c.end_date
    }];
    this.transpose_type(c.rec_pattern);
    for (scheduler.date["transpose_" + c.rec_pattern](e, h); e < c.start_date || e.valueOf() + c.event_length * 1E3 <= h.valueOf(); ) e = this.date.add(e, 1, c.rec_pattern);
    for (; e < c.end_date; ) {
        var j = this._get_rec_marker(e.valueOf(), c.id),
            i = !0;
        if (j) j.rec_type ==
            "none" ? i = !1 : f.push({
                start_date: j.start_date,
                end_date: j.end_date
            });
        else {
            var k = new Date(e.valueOf() + c.event_length * 1E3),
                l = new Date(e);
            f.push({
                start_date: l,
                end_date: k
            })
        }
        e = this.date.add(e, 1, c.rec_pattern);
        if (i && (d++, d == b)) break
    }
    return f
};
scheduler.getEvents = function (a, b) {
    var c = [],
        d;
    for (d in this._events) {
        var f = this._events[d];
        if (f && f.start_date < b && f.end_date > a) if (f.rec_pattern) {
            if (f.rec_pattern != "none") {
                var e = [];
                this.repeat_date(f, e, !0, a, b);
                for (var h = 0; h < e.length; h++) !e[h].rec_pattern && e[h].start_date < b && e[h].end_date > a && !this._rec_markers[e[h].id] && c.push(e[h])
            }
        } else f.id.toString().indexOf("#") == -1 && c.push(f)
    }
    return c
};
scheduler.config.repeat_date = "%m.%d.%Y";
scheduler.config.lightbox.sections = [{
    name: "description",
    height: 130,
    map_to: "text",
    type: "textarea",
    focus: !0
}, {


name: "time",
    height: 72,
    type: "time",
    map_to: "auto"

}, {
    name: "recurring",
    type: "recurring",
    map_to: "rec_type",
    button: "recurring"
    
}];
scheduler._copy_dummy = function () {
    this.start_date = new Date(this.start_date);
    this.end_date = new Date(this.end_date);
    this.event_length = this.event_pid = this.rec_pattern = this.rec_type = this._timed = null
};
scheduler.__recurring_template = '<div class="dhx_form_repeat"> <form> <div class="dhx_repeat_left"> <label><input class="dhx_repeat_radio" type="radio" name="repeat" value="day" />Daily</label><br /> <label><input class="dhx_repeat_radio" type="radio" name="repeat" value="week"/>Weekly</label><br /> <label><input class="dhx_repeat_radio" type="radio" name="repeat" value="month" checked />Monthly</label><br /> <label><input class="dhx_repeat_radio" type="radio" name="repeat" value="year" />Yearly</label> </div> <div class="dhx_repeat_divider"></div> <div class="dhx_repeat_center"> <div style="display:none;" id="dhx_repeat_day"> <label><input class="dhx_repeat_radio" type="radio" name="day_type" value="d"/>Every</label><input class="dhx_repeat_text" type="text" name="day_count" value="1" />day<br /> <label><input class="dhx_repeat_radio" type="radio" name="day_type" checked value="w"/>Every workday</label> </div> <div style="display:none;" id="dhx_repeat_week"> Repeat every<input class="dhx_repeat_text" type="text" name="week_count" value="1" />week next days:<br /> <table class="dhx_repeat_days"> <tr> <td> <label><input class="dhx_repeat_checkbox" type="checkbox" name="week_day" value="1" />Monday</label><br /> <label><input class="dhx_repeat_checkbox" type="checkbox" name="week_day" value="4" />Thursday</label> </td> <td> <label><input class="dhx_repeat_checkbox" type="checkbox" name="week_day" value="2" />Tuesday</label><br /> <label><input class="dhx_repeat_checkbox" type="checkbox" name="week_day" value="5" />Friday</label> </td> <td> <label><input class="dhx_repeat_checkbox" type="checkbox" name="week_day" value="3" />Wednesday</label><br /> <label><input class="dhx_repeat_checkbox" type="checkbox" name="week_day" value="6" />Saturday</label> </td> <td> <label><input class="dhx_repeat_checkbox" type="checkbox" name="week_day" value="0" />Sunday</label><br /><br /> </td> </tr> </table> </div> <div id="dhx_repeat_month"> <label><input class="dhx_repeat_radio" type="radio" name="month_type" value="d"/>Repeat</label><input class="dhx_repeat_text" type="text" name="month_day" value="1" />day every<input class="dhx_repeat_text" type="text" name="month_count" value="1" />month<br /> <label><input class="dhx_repeat_radio" type="radio" name="month_type" checked value="w"/>On</label><input class="dhx_repeat_text" type="text" name="month_week2" value="1" /><select name="month_day2"><option value="1" selected >Monday<option value="2">Tuesday<option value="3">Wednesday<option value="4">Thursday<option value="5">Friday<option value="6">Saturday<option value="0">Sunday</select>every<input class="dhx_repeat_text" type="text" name="month_count2" value="1" />month<br /> </div> <div style="display:none;" id="dhx_repeat_year"> <label><input class="dhx_repeat_radio" type="radio" name="year_type" value="d"/>Every</label><input class="dhx_repeat_text" type="text" name="year_day" value="1" />day<select name="year_month"><option value="0" selected >January<option value="1">February<option value="2">March<option value="3">April<option value="4">May<option value="5">June<option value="6">July<option value="7">August<option value="8">September<option value="9">October<option value="10">November<option value="11">December</select>month<br /> <label><input class="dhx_repeat_radio" type="radio" name="year_type" checked value="w"/>On</label><input class="dhx_repeat_text" type="text" name="year_week2" value="1" /><select name="year_day2"><option value="1" selected >Monday<option value="2">Tuesday<option value="3">Wednesday<option value="4">Thursday<option value="5">Friday<option value="6">Saturday<option value="7">Sunday</select>of<select name="year_month2"><option value="0" selected >January<option value="1">February<option value="2">March<option value="3">April<option value="4">May<option value="5">June<option value="6">July<option value="7">August<option value="8">September<option value="9">October<option value="10">November<option value="11">December</select><br /> </div> </div> <div class="dhx_repeat_divider"></div> <div class="dhx_repeat_right"> <label><input class="dhx_repeat_radio" type="radio" name="end" checked/>No end date</label><br /> <label><input class="dhx_repeat_radio" type="radio" name="end" />After</label><input class="dhx_repeat_text" type="text" name="occurences_count" value="1" />occurrences<br /> <label><input class="dhx_repeat_radio" type="radio" name="end" />End by</label><input class="dhx_repeat_date" type="text" name="date_of_end" value="' + scheduler.config.repeat_date_of_end +
    '" /><br /> </div> </form> </div> <div style="clear:both"> </div>';