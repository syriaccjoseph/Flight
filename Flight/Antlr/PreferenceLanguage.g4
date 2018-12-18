grammar PreferenceLanguage;

/*
 * Parser Rules
 */
 

 
    preferenceSet       :   setFormat1
                          | setFormat2;

    setFormat1          : '(' (preference SEPARATOR preference) ')';       
    setFormat2          : setFormat1 (SEPARATOR setFormat1)* (SEPARATOR preference)?;
    
    preference          : TEXT ;
    
/*
 * Lexer Rules
 */
 

SEPARATOR           : 'AND' | 'and' | 'OR' | 'or' | 'compromise' | 'COMPROMISE' ;
TEXT                : ('a'.. 'z')+ ;


WHITESPACE          : (' ' | '\t')+ -> skip ;