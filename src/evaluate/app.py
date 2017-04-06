from flask import Flask, request, send_file
from flask_restful import Resource, Api, reqparse
import evaluate
import uuid
import werkzeug
from os.path import splitext
import os

UPLOAD_FOLDER = "/samples/upload"
ALLOWED_EXTENSIONS = set(['jpg', 'jpeg', 'png', 'gif'])


app = Flask(__name__)
app.config['UPLOAD_FOLDER'] = UPLOAD_FOLDER

api = Api(app)


class Process_Image(Resource):

    def post(self, model):
        app.logger.debug("uploaded")
        parse = reqparse.RequestParser()
        parse.add_argument('file', type=werkzeug.datastructures.FileStorage, location='files')
        args = parse.parse_args()
        image_file = args['file']
        app.logger.debug(args)
        guid = uuid.uuid4()
        original_filename, extension = splitext(image_file.filename)
        new_filename = "%s%s" % (guid, extension)
        in_path = str(os.path.join(app.config['UPLOAD_FOLDER'], new_filename))
        out_filename = "%s.out%s" % (guid, extension)
        out_path = str(os.path.join(app.config['UPLOAD_FOLDER'], out_filename))
        image_file.save(in_path)
        model_path = str("/data/%s.ckpt" % model)
        app.logger.debug("Sending %s, Output %s, with model %s" % (in_path, out_path, model_path))
        app.logger.debug("Type of in_path %s" % type(in_path))
        evaluate.ffwd_to_img(in_path, out_path, model_path)
        #return_filename = "%s.%s%s" % (original_filename, model, extension)
        return send_file(out_path)

api.add_resource(Process_Image, '/<model>')


if __name__ == '__main__':
     app.run(debug=True, host='0.0.0.0')