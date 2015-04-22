#!/usr/bin/env ruby
# coding: utf-8

require 'mongo'
require 'json'

Encoding.default_external = Encoding::UTF_8

def Main()

	client = Mongo::Client.new(['127.0.0.1:27017'], :database => 'test')
	collection = client['sakaguradb']
	collection.find.each do |e|
		# _id があると json としては違反
		# e.delete('_id')
		puts JSON.pretty_unparse(e, :indent=>'    ')
		# puts e['会社名']
	end

end

Main()
