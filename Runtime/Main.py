import re

class Token:
    def __init__(self, type, value):
        self.type = type
        self.value = value

    def __repr__(self):
        return f"Token({self.type}, {self.value})"

class Lexer:
    def __init__(self, source_code):
        self.source_code = source_code
        self.tokens = []
        self.current_char = ''
        self.pos = -1
        self.advance()

    def advance(self):
        self.pos += 1
        self.current_char = self.source_code[self.pos] if self.pos < len(self.source_code) else None

    def tokenize(self):
        while self.current_char is not None:
            if self.current_char.isspace():
                self.advance()
            elif self.current_char.isalpha():
                self.tokens.append(self._identifier())
            elif self.current_char == '"':
                self.tokens.append(self._string())
            elif self.current_char == '#':
                self._comment()
            else:
                self.tokens.append(Token('SYMBOL', self.current_char))
                self.advance()
        return self.tokens

    def _identifier(self):
        result = ''
        while self.current_char is not None and (self.current_char.isalnum() or self.current_char == '_'):
            result += self.current_char
            self.advance()
        return Token('IDENTIFIER', result)

    def _string(self):
        result = ''
        self.advance()  # Skip the opening quote
        while self.current_char is not None and self.current_char != '"':
            result += self.current_char
            self.advance()
        self.advance()  # Skip the closing quote
        return Token('STRING', result)

    def _comment(self):
        while self.current_char is not None and self.current_char != '\n':
            self.advance()
        self.advance()

class Parser:
    def __init__(self, tokens):
        self.tokens = tokens
        self.pos = -1
        self.current_token = None
        self.advance()

    def advance(self):
        self.pos += 1
        self.current_token = self.tokens[self.pos] if self.pos < len(self.tokens) else None

    def parse(self):
        statements = []
        while self.current_token is not None:
            if self.current_token.type == 'IDENTIFIER':
                statements.append(self._statement())
            else:
                self.advance()
        return statements

    def _statement(self):
        if self.current_token.value == 'import':
            return self._import_statement()
        elif self.current_token.value == 'return':
            return self._return_statement()
        else:
            self.advance()

    def _import_statement(self):
        self.advance()  # Skip 'import'
        module_name = self.current_token.value
        self.advance()
        return f"import {module_name}"

    def _return_statement(self):
        self.advance()  # Skip 'return'
        expression = self._expression()
        return f"return {expression}"

    def _expression(self):
        expr = ''
        while self.current_token is not None and self.current_token.type != 'SYMBOL':
            expr += self.current_token.value + ' '
            self.advance()
        return expr.strip()

class Interpreter:
    def __init__(self, statements):
        self.statements = statements

    def interpret(self):
        for statement in self.statements:
            exec(statement)

def main():
    source_code = '''
    import System
    import Riverside.Esmerelda.Core.Calculation as Calculation
    return Calculation.Difference(Microsoft.Exchange.Outlook.Inbox, param=System.Formatting.Json(f"user: hello@example.com, pass: {Enigma.Vault(Source=System.Networking.Request('get', 'http://localhost:1234/$entrypoint?vault')).Pass._sha256}")), Riverside.Esmerelda.Core.Data.Query(Local:Microsoft.Exchange.Outlook.Inbox, param=System.Formatting.Json(f"user: hello@example.com")))
    '''
    lexer = Lexer(source_code)
    tokens = lexer.tokenize()
    parser = Parser(tokens)
    statements = parser.parse()
    interpreter = Interpreter(statements)
    interpreter.interpret()

if __name__ == "__main__":
    main()
