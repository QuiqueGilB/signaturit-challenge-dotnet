GNUMAKEFLAGS+=--no-print-directory --output-sync
RUN_ARGS:= $(wordlist 2,$(words $(MAKECMDGOALS)),$(MAKECMDGOALS))
$(eval $(RUN_ARGS):;@:)
cmd=
help: ## Display this help message
	@cat $(MAKEFILE_LIST) | grep -e "^[a-zA-Z_\-]*: *.*## *" | awk 'BEGIN {FS = ":.*?## "}; {printf "\033[36m%-30s\033[0m %s\n", $$1, $$2}'
start: ## Start environment
	docker-compose up -d --force-recreate
stop: ## Stop environment
	docker-compose stop
clean-docker: ## Remove containers, network, images and volumes
	docker-compose down --rmi all --volumes --remove-orphans
build: ## Build docker images
	docker-compose build $(or $(services),${RUN_ARGS})
logs: ## Show logs
	docker-compose logs -f $(or $(services),${RUN_ARGS})
shell: ## Interactive shell inside docker
	@$(MAKE) run service?=app cmd=sh
run: ## Run any command inside docker container
	docker-compose run --rm ${service} ${cmd}
