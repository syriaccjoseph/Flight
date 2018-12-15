// Generated from ../../Antlr/PreferenceLanguage.g4 by ANTLR 4.7.1
// jshint ignore: start
var antlr4 = require('antlr4/index');
var PreferenceLanguageListener = require('./PreferenceLanguageListener').PreferenceLanguageListener;
var grammarFileName = "PreferenceLanguage.g4";

var serializedATN = ["\u0003\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964",
    "\u0003\b,\u0004\u0002\t\u0002\u0004\u0003\t\u0003\u0004\u0004\t\u0004",
    "\u0004\u0005\t\u0005\u0004\u0006\t\u0006\u0003\u0002\u0003\u0002\u0003",
    "\u0002\u0003\u0002\u0005\u0002\u0011\n\u0002\u0003\u0002\u0003\u0002",
    "\u0003\u0002\u0007\u0002\u0016\n\u0002\f\u0002\u000e\u0002\u0019\u000b",
    "\u0002\u0003\u0003\u0003\u0003\u0003\u0003\u0003\u0003\u0003\u0003\u0003",
    "\u0003\u0003\u0003\u0003\u0004\u0003\u0004\u0003\u0004\u0003\u0004\u0003",
    "\u0005\u0003\u0005\u0003\u0005\u0003\u0005\u0003\u0006\u0003\u0006\u0003",
    "\u0006\u0002\u0003\u0002\u0007\u0002\u0004\u0006\b\n\u0002\u0002\u0002",
    ")\u0002\u0010\u0003\u0002\u0002\u0002\u0004\u001a\u0003\u0002\u0002",
    "\u0002\u0006!\u0003\u0002\u0002\u0002\b%\u0003\u0002\u0002\u0002\n)",
    "\u0003\u0002\u0002\u0002\f\r\b\u0002\u0001\u0002\r\u0011\u0005\u0004",
    "\u0003\u0002\u000e\u0011\u0005\u0006\u0004\u0002\u000f\u0011\u0005\b",
    "\u0005\u0002\u0010\f\u0003\u0002\u0002\u0002\u0010\u000e\u0003\u0002",
    "\u0002\u0002\u0010\u000f\u0003\u0002\u0002\u0002\u0011\u0017\u0003\u0002",
    "\u0002\u0002\u0012\u0013\f\u0003\u0002\u0002\u0013\u0014\u0007\u0006",
    "\u0002\u0002\u0014\u0016\u0005\u0002\u0002\u0004\u0015\u0012\u0003\u0002",
    "\u0002\u0002\u0016\u0019\u0003\u0002\u0002\u0002\u0017\u0015\u0003\u0002",
    "\u0002\u0002\u0017\u0018\u0003\u0002\u0002\u0002\u0018\u0003\u0003\u0002",
    "\u0002\u0002\u0019\u0017\u0003\u0002\u0002\u0002\u001a\u001b\u0007\u0003",
    "\u0002\u0002\u001b\u001c\u0005\n\u0006\u0002\u001c\u001d\u0007\u0006",
    "\u0002\u0002\u001d\u001e\u0005\n\u0006\u0002\u001e\u001f\u0003\u0002",
    "\u0002\u0002\u001f \u0007\u0004\u0002\u0002 \u0005\u0003\u0002\u0002",
    "\u0002!\"\u0005\u0004\u0003\u0002\"#\u0007\u0006\u0002\u0002#$\u0005",
    "\n\u0006\u0002$\u0007\u0003\u0002\u0002\u0002%&\u0005\n\u0006\u0002",
    "&\'\u0007\u0006\u0002\u0002\'(\u0005\u0004\u0003\u0002(\t\u0003\u0002",
    "\u0002\u0002)*\u0007\u0007\u0002\u0002*\u000b\u0003\u0002\u0002\u0002",
    "\u0004\u0010\u0017"].join("");


var atn = new antlr4.atn.ATNDeserializer().deserialize(serializedATN);

var decisionsToDFA = atn.decisionToState.map( function(ds, index) { return new antlr4.dfa.DFA(ds, index); });

var sharedContextCache = new antlr4.PredictionContextCache();

var literalNames = [ null, "'('", "')'", "'ADSFA'" ];

var symbolicNames = [ null, null, null, "NAME", "SEPARATOR", "TEXT", "WHITESPACE" ];

var ruleNames =  [ "preferenceSet", "setFormat1", "setFormat2", "setFormat3", 
                   "preference" ];

function PreferenceLanguageParser (input) {
	antlr4.Parser.call(this, input);
    this._interp = new antlr4.atn.ParserATNSimulator(this, atn, decisionsToDFA, sharedContextCache);
    this.ruleNames = ruleNames;
    this.literalNames = literalNames;
    this.symbolicNames = symbolicNames;
    return this;
}

PreferenceLanguageParser.prototype = Object.create(antlr4.Parser.prototype);
PreferenceLanguageParser.prototype.constructor = PreferenceLanguageParser;

Object.defineProperty(PreferenceLanguageParser.prototype, "atn", {
	get : function() {
		return atn;
	}
});

PreferenceLanguageParser.EOF = antlr4.Token.EOF;
PreferenceLanguageParser.T__0 = 1;
PreferenceLanguageParser.T__1 = 2;
PreferenceLanguageParser.NAME = 3;
PreferenceLanguageParser.SEPARATOR = 4;
PreferenceLanguageParser.TEXT = 5;
PreferenceLanguageParser.WHITESPACE = 6;

PreferenceLanguageParser.RULE_preferenceSet = 0;
PreferenceLanguageParser.RULE_setFormat1 = 1;
PreferenceLanguageParser.RULE_setFormat2 = 2;
PreferenceLanguageParser.RULE_setFormat3 = 3;
PreferenceLanguageParser.RULE_preference = 4;

function PreferenceSetContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = PreferenceLanguageParser.RULE_preferenceSet;
    return this;
}

PreferenceSetContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
PreferenceSetContext.prototype.constructor = PreferenceSetContext;

PreferenceSetContext.prototype.setFormat1 = function() {
    return this.getTypedRuleContext(SetFormat1Context,0);
};

PreferenceSetContext.prototype.setFormat2 = function() {
    return this.getTypedRuleContext(SetFormat2Context,0);
};

PreferenceSetContext.prototype.setFormat3 = function() {
    return this.getTypedRuleContext(SetFormat3Context,0);
};

PreferenceSetContext.prototype.preferenceSet = function(i) {
    if(i===undefined) {
        i = null;
    }
    if(i===null) {
        return this.getTypedRuleContexts(PreferenceSetContext);
    } else {
        return this.getTypedRuleContext(PreferenceSetContext,i);
    }
};

PreferenceSetContext.prototype.SEPARATOR = function() {
    return this.getToken(PreferenceLanguageParser.SEPARATOR, 0);
};

PreferenceSetContext.prototype.enterRule = function(listener) {
    if(listener instanceof PreferenceLanguageListener ) {
        listener.enterPreferenceSet(this);
	}
};

PreferenceSetContext.prototype.exitRule = function(listener) {
    if(listener instanceof PreferenceLanguageListener ) {
        listener.exitPreferenceSet(this);
	}
};



PreferenceLanguageParser.prototype.preferenceSet = function(_p) {
	if(_p===undefined) {
	    _p = 0;
	}
    var _parentctx = this._ctx;
    var _parentState = this.state;
    var localctx = new PreferenceSetContext(this, this._ctx, _parentState);
    var _prevctx = localctx;
    var _startState = 0;
    this.enterRecursionRule(localctx, 0, PreferenceLanguageParser.RULE_preferenceSet, _p);
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 14;
        this._errHandler.sync(this);
        var la_ = this._interp.adaptivePredict(this._input,0,this._ctx);
        switch(la_) {
        case 1:
            this.state = 11;
            this.setFormat1();
            break;

        case 2:
            this.state = 12;
            this.setFormat2();
            break;

        case 3:
            this.state = 13;
            this.setFormat3();
            break;

        }
        this._ctx.stop = this._input.LT(-1);
        this.state = 21;
        this._errHandler.sync(this);
        var _alt = this._interp.adaptivePredict(this._input,1,this._ctx)
        while(_alt!=2 && _alt!=antlr4.atn.ATN.INVALID_ALT_NUMBER) {
            if(_alt===1) {
                if(this._parseListeners!==null) {
                    this.triggerExitRuleEvent();
                }
                _prevctx = localctx;
                localctx = new PreferenceSetContext(this, _parentctx, _parentState);
                this.pushNewRecursionContext(localctx, _startState, PreferenceLanguageParser.RULE_preferenceSet);
                this.state = 16;
                if (!( this.precpred(this._ctx, 1))) {
                    throw new antlr4.error.FailedPredicateException(this, "this.precpred(this._ctx, 1)");
                }
                this.state = 17;
                this.match(PreferenceLanguageParser.SEPARATOR);
                this.state = 18;
                this.preferenceSet(2); 
            }
            this.state = 23;
            this._errHandler.sync(this);
            _alt = this._interp.adaptivePredict(this._input,1,this._ctx);
        }

    } catch( error) {
        if(error instanceof antlr4.error.RecognitionException) {
	        localctx.exception = error;
	        this._errHandler.reportError(this, error);
	        this._errHandler.recover(this, error);
	    } else {
	    	throw error;
	    }
    } finally {
        this.unrollRecursionContexts(_parentctx)
    }
    return localctx;
};

function SetFormat1Context(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = PreferenceLanguageParser.RULE_setFormat1;
    return this;
}

SetFormat1Context.prototype = Object.create(antlr4.ParserRuleContext.prototype);
SetFormat1Context.prototype.constructor = SetFormat1Context;

SetFormat1Context.prototype.preference = function(i) {
    if(i===undefined) {
        i = null;
    }
    if(i===null) {
        return this.getTypedRuleContexts(PreferenceContext);
    } else {
        return this.getTypedRuleContext(PreferenceContext,i);
    }
};

SetFormat1Context.prototype.SEPARATOR = function() {
    return this.getToken(PreferenceLanguageParser.SEPARATOR, 0);
};

SetFormat1Context.prototype.enterRule = function(listener) {
    if(listener instanceof PreferenceLanguageListener ) {
        listener.enterSetFormat1(this);
	}
};

SetFormat1Context.prototype.exitRule = function(listener) {
    if(listener instanceof PreferenceLanguageListener ) {
        listener.exitSetFormat1(this);
	}
};




PreferenceLanguageParser.SetFormat1Context = SetFormat1Context;

PreferenceLanguageParser.prototype.setFormat1 = function() {

    var localctx = new SetFormat1Context(this, this._ctx, this.state);
    this.enterRule(localctx, 2, PreferenceLanguageParser.RULE_setFormat1);
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 24;
        this.match(PreferenceLanguageParser.T__0);

        this.state = 25;
        this.preference();
        this.state = 26;
        this.match(PreferenceLanguageParser.SEPARATOR);
        this.state = 27;
        this.preference();
        this.state = 29;
        this.match(PreferenceLanguageParser.T__1);
    } catch (re) {
    	if(re instanceof antlr4.error.RecognitionException) {
	        localctx.exception = re;
	        this._errHandler.reportError(this, re);
	        this._errHandler.recover(this, re);
	    } else {
	    	throw re;
	    }
    } finally {
        this.exitRule();
    }
    return localctx;
};

function SetFormat2Context(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = PreferenceLanguageParser.RULE_setFormat2;
    return this;
}

SetFormat2Context.prototype = Object.create(antlr4.ParserRuleContext.prototype);
SetFormat2Context.prototype.constructor = SetFormat2Context;

SetFormat2Context.prototype.setFormat1 = function() {
    return this.getTypedRuleContext(SetFormat1Context,0);
};

SetFormat2Context.prototype.SEPARATOR = function() {
    return this.getToken(PreferenceLanguageParser.SEPARATOR, 0);
};

SetFormat2Context.prototype.preference = function() {
    return this.getTypedRuleContext(PreferenceContext,0);
};

SetFormat2Context.prototype.enterRule = function(listener) {
    if(listener instanceof PreferenceLanguageListener ) {
        listener.enterSetFormat2(this);
	}
};

SetFormat2Context.prototype.exitRule = function(listener) {
    if(listener instanceof PreferenceLanguageListener ) {
        listener.exitSetFormat2(this);
	}
};




PreferenceLanguageParser.SetFormat2Context = SetFormat2Context;

PreferenceLanguageParser.prototype.setFormat2 = function() {

    var localctx = new SetFormat2Context(this, this._ctx, this.state);
    this.enterRule(localctx, 4, PreferenceLanguageParser.RULE_setFormat2);
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 31;
        this.setFormat1();
        this.state = 32;
        this.match(PreferenceLanguageParser.SEPARATOR);
        this.state = 33;
        this.preference();
    } catch (re) {
    	if(re instanceof antlr4.error.RecognitionException) {
	        localctx.exception = re;
	        this._errHandler.reportError(this, re);
	        this._errHandler.recover(this, re);
	    } else {
	    	throw re;
	    }
    } finally {
        this.exitRule();
    }
    return localctx;
};

function SetFormat3Context(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = PreferenceLanguageParser.RULE_setFormat3;
    return this;
}

SetFormat3Context.prototype = Object.create(antlr4.ParserRuleContext.prototype);
SetFormat3Context.prototype.constructor = SetFormat3Context;

SetFormat3Context.prototype.preference = function() {
    return this.getTypedRuleContext(PreferenceContext,0);
};

SetFormat3Context.prototype.SEPARATOR = function() {
    return this.getToken(PreferenceLanguageParser.SEPARATOR, 0);
};

SetFormat3Context.prototype.setFormat1 = function() {
    return this.getTypedRuleContext(SetFormat1Context,0);
};

SetFormat3Context.prototype.enterRule = function(listener) {
    if(listener instanceof PreferenceLanguageListener ) {
        listener.enterSetFormat3(this);
	}
};

SetFormat3Context.prototype.exitRule = function(listener) {
    if(listener instanceof PreferenceLanguageListener ) {
        listener.exitSetFormat3(this);
	}
};




PreferenceLanguageParser.SetFormat3Context = SetFormat3Context;

PreferenceLanguageParser.prototype.setFormat3 = function() {

    var localctx = new SetFormat3Context(this, this._ctx, this.state);
    this.enterRule(localctx, 6, PreferenceLanguageParser.RULE_setFormat3);
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 35;
        this.preference();
        this.state = 36;
        this.match(PreferenceLanguageParser.SEPARATOR);
        this.state = 37;
        this.setFormat1();
    } catch (re) {
    	if(re instanceof antlr4.error.RecognitionException) {
	        localctx.exception = re;
	        this._errHandler.reportError(this, re);
	        this._errHandler.recover(this, re);
	    } else {
	    	throw re;
	    }
    } finally {
        this.exitRule();
    }
    return localctx;
};

function PreferenceContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = PreferenceLanguageParser.RULE_preference;
    return this;
}

PreferenceContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
PreferenceContext.prototype.constructor = PreferenceContext;

PreferenceContext.prototype.TEXT = function() {
    return this.getToken(PreferenceLanguageParser.TEXT, 0);
};

PreferenceContext.prototype.enterRule = function(listener) {
    if(listener instanceof PreferenceLanguageListener ) {
        listener.enterPreference(this);
	}
};

PreferenceContext.prototype.exitRule = function(listener) {
    if(listener instanceof PreferenceLanguageListener ) {
        listener.exitPreference(this);
	}
};




PreferenceLanguageParser.PreferenceContext = PreferenceContext;

PreferenceLanguageParser.prototype.preference = function() {

    var localctx = new PreferenceContext(this, this._ctx, this.state);
    this.enterRule(localctx, 8, PreferenceLanguageParser.RULE_preference);
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 39;
        this.match(PreferenceLanguageParser.TEXT);
    } catch (re) {
    	if(re instanceof antlr4.error.RecognitionException) {
	        localctx.exception = re;
	        this._errHandler.reportError(this, re);
	        this._errHandler.recover(this, re);
	    } else {
	    	throw re;
	    }
    } finally {
        this.exitRule();
    }
    return localctx;
};


PreferenceLanguageParser.prototype.sempred = function(localctx, ruleIndex, predIndex) {
	switch(ruleIndex) {
	case 0:
			return this.preferenceSet_sempred(localctx, predIndex);
    default:
        throw "No predicate with index:" + ruleIndex;
   }
};

PreferenceLanguageParser.prototype.preferenceSet_sempred = function(localctx, predIndex) {
	switch(predIndex) {
		case 0:
			return this.precpred(this._ctx, 1);
		default:
			throw "No predicate with index:" + predIndex;
	}
};


exports.PreferenceLanguageParser = PreferenceLanguageParser;
