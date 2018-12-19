grammar PreferenceLanguage;

/*
 * Parser Rules
 */
 


 
preference            : '(' preference ')'
                      | preference AND preference
                      | preference OR preference
                      | preference COMPROMISE preference
                      | PREFERENCE_NAME  FROM   FROM_VAL TO  FROM_VAL ;
                          
    
/*
 * Lexer Rules
 */
 
 
FROM                        : 'FROM' | 'from';
TO                          : 'TO' | 'to';
 
AND                         : 'AND' | 'and';
OR                          : 'OR' | 'or' ;
COMPROMISE                  : 'COMPROMISE' | 'compromise' ;

PREFERENCE_NAME             : [a-zA-Z]+ ;

                            
FROM_VAL                    : ('0' .. '9')+ ;


WHITESPACE          : (' ' | '\t')+ -> skip ;