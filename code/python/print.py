#!/usr/bin/env python
# coding: utf-8


import pymongo
import json
import datetime

def _conversion(unknown):

	if isinstance(unknown, datetime.datetime):
		return unknown.isoformat()
	try:
		return str(unknown)
	except:
		raise TypeError(repr(unknown) + " is not JSON serializable")

def _main():

	client = pymongo.MongoClient('localhost', 27017, )

	db = client['test']

	collection = db['sakaguradb']

	for e in collection.find():

		# 表示用に _id を消す
		e['_id'] = "..."
		# del e['_id']
		print json.dumps(e, ensure_ascii=False,
				sort_keys=True, indent=4, default=_conversion)

_main()

