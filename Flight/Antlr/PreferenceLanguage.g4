grammar PreferenceLanguage;

/*
 * Parser Rules
 */
 

preferenceSet       :   preference;
preference          : '"' .*? '"' ;

 
/*
 * Lexer Rules
 */
 
 
 
SEPARATOR           : 'AND' | 'and' | 'OR' | 'or'| 'COMPROMISE' | 'compromise';

