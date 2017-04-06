from flask import Flask, request, send_file
from flask_restful import Resource, Api
import evaluate

app = Flask(__name__)
api = Api(app)


class Process_Image(Resource):
    def post(self, model):
        return {'message': model}

api.add_resource(Process_Image, '/<model>')


if __name__ == '__main__':
     app.run(debug=True, host='0.0.0.0')