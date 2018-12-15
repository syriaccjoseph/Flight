grammar PreferenceLanguage;

/*
 * Parser Rules
 */
 

 
    preferenceSet       :   setFormat1
                          | setFormat2
                          | setFormat3
                          | preferenceSet SEPARATOR preferenceSet;


    setFormat1          : '(' (preference SEPARATOR preference) ')';
                        
    setFormat2          : setFormat1 SEPARATOR preference;

    setFormat3          : preference SEPARATOR setFormat1;
                        
    preference          :   TEXT ;
    
/*
 * Lexer Rules
 */
 
NAME : 'ADSFA';
// and may follow with any number of alphanumerical characters"

SEPARATOR           : 'AND' | 'and' | 'OR' | 'or' | 'compromise' | 'COMPROMISE';
TEXT
    : [a-z]*
    ;


WHITESPACE          : (' '|'\t')+ -> skip ;