#!/usr/bin/env ruby
# coding: utf-8

require 'mongo'

Encoding.default_external = Encoding::UTF_8

def Main()

	puts '### start ###'

	client = Mongo::Client.new(['127.0.0.1:27017'], :database => 'test')

	puts '--- end ---'

end

Main()
