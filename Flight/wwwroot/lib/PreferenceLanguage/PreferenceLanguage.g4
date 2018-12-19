grammar PreferenceLanguage;

/*
 * Parser Rules
 */
 


 
preference            : '(' preference ')'
                      | preference AND preference
                      | preference OR preference
                      | preference COMPROMISE preference
                      | PREFERENCE_NAME  FROM   FROM_VAL   TO   TO_VAL ;
                          
    
/*
 * Lexer Rules
 */
 
 
FROM                        : 'FROM' | 'from';
TO                          : 'TO' | 'to';
 
AND                         : 'AND' | 'and';
OR                          : 'OR' | 'or' ;
COMPROMISE                  : 'COMPROMISE' | 'compromise' ;

PREFERENCE_NAME             : [a-zA-Z]+ ;

VAL                         : '0' 
                            | [1-9] [0-9]*;
                            
FROM_VAL                    : VAL  ;
TO_VAL                      : VAL ;


WHITESPACE          : (' ' | '\t')+ -> skip ;