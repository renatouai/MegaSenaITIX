    /**
 * INSPINIA - Responsive Admin Theme
 *
 */
(function () {
    angular.module('inspinia', [
         'ui.router',                    // Routing
        'oc.lazyLoad',                  // ocLazyLoad
        'ui.bootstrap',                 // Ui Bootstrap
        'pascalprecht.translate',       // Angular Translate
        'ngIdle',                       // Idle timer
        'ngSanitize',
        'ngTable',
        'cp.ngConfirm',
        'LocalStorageModule',
        'blockUI',
        'brasil.filters',
        'ui.utils.masks',

        'app.dashboard',
        'app.sorteio',
        'app.jogador'
          

        /*,

        'app.sorteio',
        'app.jogador',
        'app.jogo' */
    ]);

    //   'app.convenio',
    angular.module("ngLocale", [], ["$provide", function ($provide) {
        var PLURAL_CATEGORY = { ZERO: "zero", ONE: "one", TWO: "two", FEW: "few", MANY: "many", OTHER: "other" };
        $provide.value("$locale", {
            "DATETIME_FORMATS": {
                "AMPMS": [
                  "AM",
                  "PM"
                ],
                "DAY": [
                  "domingo",
                  "segunda-feira",
                  "ter\u00e7a-feira",
                  "quarta-feira",
                  "quinta-feira",
                  "sexta-feira",
                  "s\u00e1bado"
                ],
                "ERANAMES": [
                  "antes de Cristo",
                  "depois de Cristo"
                ],
                "ERAS": [
                  "a.C.",
                  "d.C."
                ],
                "FIRSTDAYOFWEEK": 6,
                "MONTH": [
                  "janeiro",
                  "fevereiro",
                  "mar\u00e7o",
                  "abril",
                  "maio",
                  "junho",
                  "julho",
                  "agosto",
                  "setembro",
                  "outubro",
                  "novembro",
                  "dezembro"
                ],
                "SHORTDAY": [
                  "dom",
                  "seg",
                  "ter",
                  "qua",
                  "qui",
                  "sex",
                  "s\u00e1b"
                ],
                "SHORTMONTH": [
                  "jan",
                  "fev",
                  "mar",
                  "abr",
                  "mai",
                  "jun",
                  "jul",
                  "ago",
                  "set",
                  "out",
                  "nov",
                  "dez"
                ],
                "STANDALONEMONTH": [
                  "janeiro",
                  "fevereiro",
                  "mar\u00e7o",
                  "abril",
                  "maio",
                  "junho",
                  "julho",
                  "agosto",
                  "setembro",
                  "outubro",
                  "novembro",
                  "dezembro"
                ],
                "WEEKENDRANGE": [
                  5,
                  6
                ],
                "fullDate": "EEEE, d 'de' MMMM 'de' y",
                "longDate": "d 'de' MMMM 'de' y",
                "medium": "d 'de' MMM 'de' y HH:mm:ss",
                "mediumDate": "d 'de' MMM 'de' y",
                "mediumTime": "HH:mm:ss",
                "short": "dd/MM/yy HH:mm",
                "shortDate": "dd/MM/yy",
                "shortTime": "HH:mm"
            },
            "NUMBER_FORMATS": {
                "CURRENCY_SYM": "R$",
                "DECIMAL_SEP": ",",
                "GROUP_SEP": ".",
                "PATTERNS": [
                  {
                      "gSize": 3,
                      "lgSize": 3,
                      "maxFrac": 3,
                      "minFrac": 0,
                      "minInt": 1,
                      "negPre": "-",
                      "negSuf": "",
                      "posPre": "",
                      "posSuf": ""
                  },
                  {
                      "gSize": 3,
                      "lgSize": 3,
                      "maxFrac": 2,
                      "minFrac": 2,
                      "minInt": 1,
                      "negPre": "-\u00a4",
                      "negSuf": "",
                      "posPre": "\u00a4",
                      "posSuf": ""
                  }
                ]
            },
            "id": "pt-br",
            "localeID": "pt_BR",
            "pluralCat": function (n, opt_precision) { if (n >= 0 && n <= 2 && n != 2) { return PLURAL_CATEGORY.ONE; } return PLURAL_CATEGORY.OTHER; }
        });
    }]);


    angular.module('brasil.filters', []).filter('cpf', function () {
        return function (input) {
            var str = input + '';
            str = str.replace(/\D/g, '');
            str = str.replace(/(\d{3})(\d)/, "$1.$2");
            str = str.replace(/(\d{3})(\d)/, "$1.$2");
            str = str.replace(/(\d{3})(\d{1,2})$/, "$1-$2");
            return str;
        };
    }).filter('realbrasileiro', function () {
        return function (int) {
            var tmp = int.toString().indexOf('.') !== -1 ? int + '' : int + '.00';
            var res = tmp.replace('.', '');
            tmp = res.replace(',', '');
            var neg = false;
            if (tmp.indexOf('-') === 0) {
                neg = true;
                tmp = tmp.replace('-', '');
            }
            if (tmp.length === 1) {
                tmp = '0' + tmp;
            }
            tmp = tmp.replace(/([0-9]{2})$/g, ',$1');
            if (tmp.length > 6) {
                tmp = tmp.replace(/([0-9]{3}),([0-9]{2}$)/g, '.$1,$2');
            }
            if (tmp.length > 9) {
                tmp = tmp.replace(/([0-9]{3}).([0-9]{3}),([0-9]{2}$)/g, '.$1.$2,$3');
            }
            if (tmp.length > 12) {
                tmp = tmp.replace(/([0-9]{3}).([0-9]{3}).([0-9]{3}),([0-9]{2}$)/g, '.$1.$2.$3,$4');
            }
            if (tmp.indexOf('.') === 0) {
                tmp = tmp.replace('.', '');
            }
            if (tmp.indexOf(',') === 0) {
                tmp = tmp.replace(',', '0,');
            }
            return (neg ? '-' + tmp : tmp);
        };
    }).filter('tel', function () {
        return function (input) {
            var str = input + '';
            str = str.replace(/\D/g, '');
            if (str.length === 11) {
                str = str.replace(/^(\d{2})(\d{5})(\d{4})/, '($1) $2-$3');
            } else {
                str = str.replace(/^(\d{2})(\d{4})(\d{4})/, '($1) $2-$3');
            }
            return str;
        };
    });

})();



// Other libraries are loaded dynamically in the config.js file using the library ocLazyLoad