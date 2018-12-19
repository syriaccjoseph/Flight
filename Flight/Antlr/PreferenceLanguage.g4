grammar PreferenceLanguage;

/*
 * Parser Rules
 */
 


 
preference            : '(' preference ')'                                      #parenthesisPreference
                      | preference AND preference                               #andPreference
                      | preference OR preference                                #orPreference
                      | preference COMPROMISE preference                        #compromisePreference
                      | PREFERENCE_NAME  FROM  VAL TO  VAL                      #atomPreference
                      ;    
    
/*
 * Lexer Rules
 */
 
 
FROM                        : 'FROM' | 'from';
TO                          : 'TO' | 'to';
 
AND                         : 'AND' | 'and';
OR                          : 'OR' | 'or' ;
COMPROMISE                  : 'COMPROMISE' | 'compromise' ;

PREFERENCE_NAME             : [a-zA-Z]+ ;

                            
VAL                    : ('0' .. '9')+ ;


WHITESPACE          : (' ' | '\t')+ -> skip ;